Imports System.IO
Imports System.Text

Public Structure StructureAgenda
    Dim Index() As String
    Dim NNote() As String
End Structure

Public Structure StructureUtilisateur
    Dim Pseudonyme As String
    Dim Pass As String
    Dim Privilege As String
End Structure

Public Class GestionFichier

    Private ILectureUtilisateurs As Integer
    Private ILectureAgenda As Integer
    Private Utilisateurs() As StructureUtilisateur
    Private Agenda As StructureAgenda

    Private Capteur As Integer
    Private IDUtilisateur As String

    'Procédure de lecture du fichier regroupant les utilisateurs
    Private Sub LectureFichierUtilisateurs(ByVal Fichier As String)
        Try
            Dim LectureLigne As String
            Dim TableauDivision(50) As String
            'On ouvre le fichier
            Dim LecteurFichier As New StreamReader(Fichier, System.Text.Encoding.UTF8)

            'On récupère tous les utilisateurs et leurs logins dans une structure
            Do
                LectureLigne = LecteurFichier.ReadLine()
                ReDim Preserve Utilisateurs(ILectureUtilisateurs)
                TableauDivision = Split(LectureLigne, ";")
                Utilisateurs(ILectureUtilisateurs).Pass = TableauDivision(0)
                Utilisateurs(ILectureUtilisateurs).Pseudonyme = TableauDivision(1)
                Utilisateurs(ILectureUtilisateurs).Privilege = TableauDivision(2)
                ILectureUtilisateurs += 1
            Loop While LecteurFichier.Peek <> -1

            ILectureUtilisateurs -= 1

            'Fermeture du lecteur et de son fichier
            LecteurFichier.Close()

        Catch ex As Exception

            'Si plantage, on lance la méthode backup liée à la récupération des fichiers et on relancera la méthode LectureFichierUtilisateurs
            Dim FichierCible As String = "./FichierSauvegarde/UtilisateursOld.csv"
            File.Delete(Fichier)
            File.Copy(FichierCible, Fichier)
            ILectureUtilisateurs = 0
            LectureFichierAgenda(Fichier)

        End Try
    End Sub

    'Méthode qui retourne un tableau reprenant l'ensemble des utilisateurs, si pas d'utilisateur, retourne nothing
    Public Function DonnerUtilisateurs() As String()
        Dim MonTableau() As String
        Dim i As Integer
        For Each Valeur In Utilisateurs
            ReDim Preserve MonTableau(i)
            MonTableau(i) = Valeur.Pseudonyme
            i += 1
        Next
        If MonTableau IsNot Nothing And MonTableau.Length > 0 Then

            Return MonTableau

        Else : Return Nothing
        End If

    End Function


    Public Function DonnerPrivilieges() As String()
        Dim MonTableau() As String
        Dim i As Integer
        For Each Valeur In Utilisateurs
            ReDim Preserve MonTableau(i)
            MonTableau(i) = Valeur.Privilege
            i += 1
        Next
        If MonTableau IsNot Nothing And MonTableau.Length > 0 Then

            Return MonTableau

        Else : Return Nothing
        End If
    End Function

    'Méthode de vérification d'utilisateur renvoie -1 ou 0 ou 1 (-1 : N'existe pas ou erreur de MdP/0 : utilisateur/1 : Admin)
    Public Function VerificationUtilisateur(ByVal MdP As String, ByVal NomUtilisateur As String) As Integer

        Dim Cpt As Integer
        Dim Comparateur As Integer
        Dim Privilege As Integer
        Dim Fichier As String = "./FichiersSauvegarde/Utilisateurs.csv"

        'On lance la lecture du fichier "Utilisateurs"
        LectureFichierUtilisateurs(Fichier)

        'On boucle tant que l'on n'a pas trouvé le user
        Do
            Comparateur = String.Compare(Utilisateurs(Cpt).Pseudonyme, NomUtilisateur)
            Cpt += 1
        Loop While (Comparateur <> 0 And Cpt - 1 <> ILectureUtilisateurs)

        'On compare le MDP donné par l'utilisateur et celui sauvegardé dans le tableau
        Comparateur = String.Compare(Utilisateurs(Cpt - 1).Pass, MdP)

        'On vérifie son niveau de privilège
        If Comparateur = 0 Then
            Capteur = 0
            IDUtilisateur = Utilisateurs(Cpt - 1).Pseudonyme
            Privilege = CType((Utilisateurs(Cpt - 1).Privilege), Integer)
            Comparateur += Privilege
        Else
            Comparateur = -1
        End If

        'On retourne le résultat : si retourne 0: Utilisateur de base, si retourne 1 : Administrateur, si retourne : -1 : N'existe pas
        Return Comparateur
    End Function

    'Procédure de récupération des données liées à l'agenda
    Private Sub LectureFichierAgenda(ByVal Fichier As String)

        Try
            Dim TableauDivision(2) As String
            Dim LectureLigne As String
            'On initialise le lecteur de fichier avec la norme UTF8 et on ouvre le fichier
            Dim LecteurFichier As New StreamReader(Fichier, System.Text.Encoding.UTF8)

            'On récupère l'ensemble des données dans une structure
            While LecteurFichier.Peek <> -1
                LectureLigne = LecteurFichier.ReadLine()
                ReDim Preserve Agenda.Index(ILectureAgenda)
                ReDim Preserve Agenda.NNote(ILectureAgenda)
                TableauDivision = Split(LectureLigne, ";")
                Agenda.Index(ILectureAgenda) = TableauDivision(0)
                Agenda.NNote(ILectureAgenda) = TableauDivision(1)
                ILectureAgenda += 1
            End While

            LecteurFichier.Close()
            Dim FichierCible = "./FichiersSauvegarde/" & IDUtilisateur & "Old.csv"
            File.Delete(FichierCible)
            File.Copy(Fichier, FichierCible)

        Catch ex As Exception
            'On récupère la sauvegarde que l'on renomme puis on relance la procédure
            Dim FichierSource As String = "./FichiersSauvegarde/" & IDUtilisateur & "Old.csv"
            Dim FichierCible As String = "./FichiersSauvegarde/" & IDUtilisateur & ".csv"

            'File.Delete(FichierCible)
            'File.Copy(Fichier, FichierCible)
            'ILectureAgenda = 0
            'LectureFichierAgenda(FichierCible)

        End Try
    End Sub

    'Méthode qui récupère les notes de l'utilisateur à l'heure du jour demandé
    Public Function LectureAgenda(ByVal DateJour As Integer, ByVal DateHeure As Integer) As String

        Try
            Dim Index As String
            Dim Informations As String
            Dim i As Integer
            Dim Compare As Integer = -1
            Dim Fichier As String = "./FichiersSauvegarde/" & IDUtilisateur & ".csv"

            'Si l'on n'a pas encore chargé les données venant du fichier, on lance son chargement
            If Capteur = 0 Then
                LectureFichierAgenda(Fichier)
                Capteur += 1
            End If

            'On récupère et envoie l'information demandée
            Index = CType((DateJour * 100) + DateHeure, String)
            While i < ILectureAgenda And Compare <> 0
                Compare = String.Compare(Agenda.Index(i), Index)
                i += 1
            End While

            If Compare = 0 Then
                Informations = Agenda.NNote(i - 1)
                Return Informations
            Else
                Informations = ""
                Return Informations
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return "#erreur"
        End Try


    End Function

    'Méthode de gestion des utilisateurs proposant deux choix : l'ajout, le retrait d'un utilisateur
    Public Function GestionUtilisateurs(ByVal NomUtilisateur As String, ByVal AjoutSupr As Integer, Optional ByVal MdP As String = "", Optional ByVal Privilege As Integer = 0) As Boolean
        Dim Verif As Boolean
        Select Case AjoutSupr
            Case 1
                If MdP = "" Then
                    Return False
                End If
                Return Verif = AjoutUtilisateur(NomUtilisateur, MdP, Privilege)
            Case 2
                Return Verif = SuprUtilisateur(NomUtilisateur)
        End Select
    End Function

    'Méthode qui ajoute les utilisateurs à la structure StructureUtilisateur et retourne true si l'ajout a fonctionné et false en cas d'échec
    Private Function AjoutUtilisateur(ByVal NomUtilisateur As String, ByVal MdP As String, ByVal Privilege As Integer) As Boolean
        Dim LecteurFichier As StreamWriter
        Dim CopieurFichier As StreamWriter
        Dim Ligne As String
        ReDim Preserve Utilisateurs(ILectureUtilisateurs + 1)

        'Ajout de l'utilisateur dans le tableau de structure
        ILectureUtilisateurs += 1
        Utilisateurs(ILectureUtilisateurs).Pseudonyme = NomUtilisateur
        Utilisateurs(ILectureUtilisateurs).Pass = MdP
        Utilisateurs(ILectureUtilisateurs).Privilege = CType(Privilege, String)

        Try
            'Ajout de l'utilisateur dans le fichier correspondant
            LecteurFichier = New StreamWriter("./FichiersSauvegarde/Utilisateurs.csv", True, Encoding.UTF8)

            Ligne = MdP & ";" & NomUtilisateur & ";" & Privilege
            LecteurFichier.WriteLine(Ligne)

            LecteurFichier.Close()

            'On créé le fichier de l'utilisateur
            Dim MonChemin As String = "./FichiersSauvegarde/" & NomUtilisateur & ".csv"
            File.Create(MonChemin).Dispose()
            CopieurFichier = New StreamWriter(MonChemin, False, Encoding.UTF8)
            Ligne = " 000;000 "
            CopieurFichier.WriteLine(Ligne)

            CopieurFichier.Close()
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    'Méthode qui supprime un utilisateurs de la structure StructureUtilisateur et du fichier correspondant puis retourne true si l'ajout a fonctionné et false en cas d'échec
    Public Function SuprUtilisateur(ByVal NomUtilisateur As String) As Boolean
        Dim Comparateur As Integer
        Dim Cpt As Integer
        Dim i As Integer
        Dim Provisoire() As StructureUtilisateur

        Try
            'On repère où se trouve l'utilisateur dans le tableau
            Do
                Comparateur = String.Compare(NomUtilisateur, Utilisateurs(Cpt).Pseudonyme)
                Cpt += 1
            Loop While (Cpt - 1) <> ILectureUtilisateurs And Comparateur <> 0

            If Comparateur = 0 Then
                'Si l'utilisateur est trouvé alors on charge la liste des users dans un tableau provisoire
                Do
                    ReDim Preserve Provisoire(i)

                    Provisoire(i).Pass = Utilisateurs(i).Pass
                    Provisoire(i).Pseudonyme = Utilisateurs(i).Pseudonyme
                    Provisoire(i).Privilege = Utilisateurs(i).Privilege
                    i += 1
                Loop While (i - 1) <> ILectureUtilisateurs

                'On réinitialise le tableau Utilisateurs
                ILectureUtilisateurs -= 1
                ReDim Utilisateurs(ILectureUtilisateurs)
                i = 0

                Dim LecteurFichier As StreamWriter = New StreamWriter("./FichiersSauvegarde/Utilisateurs.csv", False, Encoding.UTF8)

                'On copie le tableau provisoire dans Utilisateurs sans l'utilisateur que l'on veut supprimer
                Do
                    If i <> Cpt Then
                        Utilisateurs(i).Pass = Provisoire(i).Pass
                        Utilisateurs(i).Privilege = Provisoire(i).Privilege
                        Utilisateurs(i).Pseudonyme = Provisoire(i).Pseudonyme

                        LecteurFichier.WriteLine(Utilisateurs(i).Pass & ";" & Utilisateurs(i).Pseudonyme & ";" & Utilisateurs(i).Privilege)
                    End If
                    LecteurFichier.Close()
                    i += 1
                Loop While (i - 1) <> ILectureUtilisateurs

                'On supprime le fichier Agenda de l'utilisateur et son back up
                File.Delete("./FichiersSauvegarde/" & NomUtilisateur & ".csv")
                File.Delete("./FichiersSauvegarde/" & NomUtilisateur & "Old.csv")
                'File.delete("./FichiersSauvegarde/" & IDUtilisateur & ".csv")
                Return True
            Else
                Return False
            End If

        Catch ex As Exception

            Return False

        End Try
    End Function

    'Méthode qui modifie un utilisateur de la structure StructureUtilisateur ainsi que dans le fichier correspondant puis retourne true si la modification a fonctionné et false en cas d'échec
    Public Function ModifUtilisateur(ByVal NomUtilisateur As String, ByVal NouveauNom As String, ByVal NouveauMdP As String, ByVal NouveauPrivilege As Integer) As Boolean

        Dim Cpt As Integer
        Dim Comparateur As Integer
        Dim i As Integer

        'On cherche l'utilisateur dans le tableau Utilisateurs
        Do
            Comparateur = String.Compare(Utilisateurs(Cpt).Pseudonyme, NomUtilisateur)
            Cpt += 1
        Loop While (Cpt - 1) <> ILectureUtilisateurs And Comparateur <> 0

        'Si l'utilisateur est trouvé alors on lui donne ses nouveaux paramètres
        If Comparateur = 0 Then

            Utilisateurs(Cpt - 1).Pseudonyme = NouveauNom
            Utilisateurs(Cpt - 1).Pass = NouveauMdP
            Utilisateurs(Cpt - 1).Privilege = NouveauPrivilege

            Dim LecteurFichier As StreamWriter = New StreamWriter("./FichiersSauvegarde/Utilisateurs.csv", False, Encoding.UTF8)

            Do
                Dim Ligne As String = Utilisateurs(i).Pass & ";" & Utilisateurs(i).Pseudonyme & ";" & Utilisateurs(i).Privilege
                LecteurFichier.WriteLine(Ligne)
                i += 1
            Loop While (i - 1) <> ILectureUtilisateurs

            LecteurFichier.Close()
            File.Move("./FichiersSauvegarde/" & NomUtilisateur & ".csv", "./FichiersSauvegarde/" & NouveauNom & ".csv")
            Return True
        Else
            Return False
        End If

    End Function

    'Ecrit dans le fichier ce que l'utilisateur veut sauvegarder à la date et à l'heure mentionnées
    Public Function EcritureFichierAgenda() As Boolean
        Dim Cpt As Integer
        Dim LigneAEcrire As String
        Dim Fichier As String = "./FichiersSauvegarde/" & IDUtilisateur & ".csv"
        Dim LecteurFichier As StreamWriter = New StreamWriter(Fichier, False, Encoding.UTF8)

        Try
            Do
                LigneAEcrire = Agenda.Index(Cpt) & ";" & Agenda.NNote(Cpt)
                LecteurFichier.WriteLine(LigneAEcrire)
                Cpt += 1
            Loop While Cpt < ILectureAgenda

            Capteur = 0
            ILectureAgenda = 0
            ILectureUtilisateurs = 0
            LecteurFichier.Close()
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    'Ecrit dans la mémoire vive (structure) les nouvelles données, mais ne sauvegarde pas dans le fichier !
    Public Function EcritureAgenda(ByVal DateJour As Integer, ByVal DateHeure As Integer, ByVal Information As String) As Boolean
        Dim Index As Integer = (DateJour * 100) + DateHeure
        Dim i As Integer
        Dim Nouveau As Boolean = False
        Try
            If Not (String.IsNullOrEmpty(Information) Or String.IsNullOrWhiteSpace(Information)) Then
                For i = 0 To ILectureAgenda - 1
                    If Agenda.Index(i) = Index Then
                        Agenda.NNote(i) = Information
                        Return True
                    ElseIf Nouveau = False Then
                        Nouveau = True
                    End If
                Next

                If Nouveau = True Then
                    ReDim Preserve Agenda.Index(ILectureAgenda)
                    ReDim Preserve Agenda.NNote(ILectureAgenda)
                    Agenda.Index(ILectureAgenda) = Index
                    Agenda.NNote(ILectureAgenda) = Information
                    ILectureAgenda += 1
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function CreationUtilisateurPossible(ByVal NomUtilisateur) As Boolean
        For Each Valeur In Utilisateurs
            If NomUtilisateur = Valeur.Pseudonyme Then
                Return False
            End If
        Next
        Return True
    End Function
End Class
