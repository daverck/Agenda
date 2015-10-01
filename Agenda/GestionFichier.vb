Imports System.IO
Imports System.Text

Public Class GestionFichier

    Private Structure StructureUtilisateur
        Dim Pseudonyme As String
        Dim Pass As String
        Dim Privilege As String
    End Structure

    Private Structure StructureAgenda
        Dim NNote() As String
    End Structure

    Private ILectureUtilisateurs As Integer
    Private ILectureAgenda As Integer = 1
    Private Utilisateurs() As StructureUtilisateur
    Private Agenda() As StructureAgenda

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
            Dim LectureLigne As String
            'On initialise le lecteur de fichier avec la norme UTF8 et on ouvre le fichier
            Dim LecteurFichier As New StreamReader(Fichier, System.Text.Encoding.UTF8)

            'On récupère l'ensemble des données dans une structure
            Do
                For i = 0 To 23
                    LectureLigne = LecteurFichier.ReadLine()
                    ReDim Preserve Agenda(ILectureAgenda)
                    ReDim Preserve Agenda(ILectureAgenda).NNote(23)
                    Agenda(ILectureAgenda).NNote(i) = LectureLigne
                Next
                ILectureAgenda += 1
            Loop While LecteurFichier.Peek <> -1

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

        Dim Informations As String
        Static Capteur As Integer = 0
        DateHeure += 1
        Dim Fichier As String = "./FichiersSauvegarde/" & IDUtilisateur & ".csv"

        'Si l'on n'a pas encore chargé les données venant du fichier, on lance son chargement
        If Capteur = 0 Then
            LectureFichierAgenda(Fichier)
            Capteur += 1
        End If

        'On récupère et envoie l'information demandée
        Informations = Agenda(DateJour).NNote(DateHeure)
        Return Informations

    End Function

    'Méthode de gestion des utilisateurs proposant deux choix : l'ajout, le retrait d'un utilisateur
    Public Function GestionUtilisateurs(ByVal NomUtilisateur As String, ByVal MdP As String, ByVal AjoutSupr As Integer, Optional ByVal Privilege As Integer = 0) As Boolean
        Dim Verif As Boolean
        Select Case AjoutSupr
            Case 1
                Verif = AjoutUtilisateur(NomUtilisateur, MdP, Privilege)
            Case 2
                Verif = SuprUtilisateur(NomUtilisateur)
        End Select

        Return Verif
    End Function

    'Méthode qui ajoute les utilisateurs à la structure StructureUtilisateur et retourne true si l'ajout a fonctionné et false en cas d'échec
    Private Function AjoutUtilisateur(ByVal NomUtilisateur As String, ByVal MdP As String, ByVal Privilege As Integer) As Boolean

        Try
            'Ajout de l'utilisateur dans le tableau de structure
            ReDim Preserve Utilisateurs(ILectureUtilisateurs + 1)
            ILectureUtilisateurs += 1
            Utilisateurs(ILectureUtilisateurs).Pseudonyme = NomUtilisateur
            Utilisateurs(ILectureUtilisateurs).Pass = MdP
            Utilisateurs(ILectureUtilisateurs).Privilege = CType(Privilege, String)

            'Ajout de l'utilisateur dans le fichier correspondant
            Dim LecteurFichier As StreamWriter = New StreamWriter("./FichiersSauvegarde/Utilisateurs.csv", True, Encoding.UTF8)
            Dim Ligne As String

            Ligne = MdP & ";" & NomUtilisateur & ";" & Privilege
            LecteurFichier.WriteLine(Ligne)

            LecteurFichier.Close()
            Return True

        Catch ex As Exception

            Return False

        End Try
    End Function

    'Méthode qui supprime un utilisateurs de la structure StructureUtilisateur et du fichier correspondant puis retourne true si l'ajout a fonctionné et false en cas d'échec
    Private Function SuprUtilisateur(ByVal NomUtilisateur As String) As Boolean

        Try

            Dim Comparateur As Integer
            Dim Cpt As Integer
            Dim i As Integer
            Dim Provisoire() As StructureUtilisateur

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

                    i += 1
                Loop While (i - 1) <> ILectureUtilisateurs

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
                LecteurFichier.WriteLine(Utilisateurs(i).Pass & ";" & Utilisateurs(i).Pseudonyme & ";" & Utilisateurs(i).Privilege)
            Loop While (i - 1) <> ILectureUtilisateurs

            LecteurFichier.Close()
            Return True
        Else
            Return False
        End If

    End Function

    'Ecrit dans le fichier ce que l'utilisateur veut sauvegarder à la date et à l'heure mentionnées
    Public Function EcritureFichierAgenda(ByVal DateJour As String, ByVal DateHeure As String) As Boolean

        Try
            Dim CptJours As Integer
            Dim Fichier As String = "./FichiersSauvegarde/" & IDUtilisateur & ".csv"
            Dim LecteurFichier As StreamWriter = New StreamWriter(Fichier, False, Encoding.UTF8)
            Do
                For CptHeures = 0 To 23
                    LecteurFichier.WriteLine(Agenda(CptJours).NNote(CptHeures))
                Next

                CptJours += 1
            Loop While CptJours <> 366

            LecteurFichier.Close()
            Return True

        Catch ex As Exception

            Return False

        End Try
    End Function

    'Ecrit dans la mémoire vive (structure) les nouvelles données, mais ne sauvegarde pas dans le fichier !
    Public Function EcritureAgenda(ByVal DateJour As Integer, ByVal DateHeure As Integer, ByVal Information As String) As Boolean
        Try
            Agenda(DateJour - 1).NNote(DateHeure - 1) = Information
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
