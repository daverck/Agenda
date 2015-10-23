Imports Microsoft.Win32
Imports System.IO
Imports System.Security
Imports System.Security.Permissions
Imports System.Security.Cryptography

<Assembly: RegistryPermission(SecurityAction.RequestMinimum, All:="HKEY_CURRENT_USER\SOFTWARE\Secure")> 
<Assembly: FileIOPermission(SecurityAction.RequestMinimum, Unrestricted:=True)> 


Public Class Cryptage

    'Déclaration des délégués pour le suivi de l'opération asynchrone.
    Delegate Sub StartChiffreEventHandler(ByVal sender As Object, ByVal e As ChiffreEventArgs)
    Delegate Sub EndChiffreEventHandler(ByVal sender As Object, ByVal e As ChiffreEventArgs)
    Delegate Sub ProgressChiffreEventHandler(ByVal sender As Object, ByVal e As ChiffreEventArgs)

    'Déclaration des évènements pour le suivi de l'opération asynchrone.
    Public Event DebutChiffreEvent As StartChiffreEventHandler
    Public Event FinChiffreEvent As EndChiffreEventHandler
    Public Event ProgresChiffreEvent As ProgressChiffreEventHandler

    Private RegApp As RegistryKey
    Private STDES As TripleDESCryptoServiceProvider
    Public Sub New()

        'Vérification du registre.
        RegApp = Registry.CurrentUser.OpenSubKey("Software\\Secure\\chPers", True)
        STDES = New TripleDESCryptoServiceProvider

        If RegApp Is Nothing Then

            With STDES 'On génére une clé de chiffrement et un vecteur.
                .GenerateIV()
                .GenerateKey()
            End With

            'On les met dans le registre.
            RegApp = Registry.CurrentUser.CreateSubKey("Software\\Secure\\chPers")
            RegApp.SetValue("cle", Convert.ToBase64String(STDES.Key))
            RegApp.SetValue("vecteur", Convert.ToBase64String(STDES.IV))

        Else

            With STDES 'On récupère les valeurs du registre.
                .Key = Convert.FromBase64String(CType(RegApp.GetValue("cle"), String))
                .IV = Convert.FromBase64String(CType(RegApp.GetValue("vecteur"), String))
            End With

        End If

    End Sub

    Public Sub Chiffrement(ByVal Fichier As String)

        If File.Exists(Fichier) Then

            Dim FichierSource As New FileStream(Fichier, FileMode.Open, FileAccess.Read)
            Dim FichierCible As New FileStream(Path.ChangeExtension(Fichier, "cry"), _
 FileMode.Create, FileAccess.Write)
            Dim ChiffreFlux As New CryptoStream(FichierCible, STDES.CreateEncryptor, CryptoStreamMode.Write)
            FichierCible.SetLength(0)

            Dim bin(100) As Byte
            Dim LongTotale As Long = FichierSource.Length
            RaiseEvent DebutChiffreEvent(Me, New ChiffreEventArgs(0, LongTotale))
            Dim LongEffectue As Long = 0
            Dim BlocLen As Integer

            'Traitement des données.
            While LongEffectue < LongTotale
                BlocLen = FichierSource.Read(bin, 0, 100)
                ChiffreFlux.Write(bin, 0, BlocLen)
                LongEffectue += BlocLen
                RaiseEvent ProgresChiffreEvent(Me, New ChiffreEventArgs(LongEffectue, LongTotale))
            End While

            RaiseEvent FinChiffreEvent(Me, New ChiffreEventArgs(LongEffectue, LongTotale))
            ChiffreFlux.Close()
            FichierSource.Close()
            FichierCible.Close()
        Else

            Throw New FileNotFoundException("Fichier introuvable", Fichier)

        End If

    End Sub

    Public Sub Dechiffrement(ByVal Fichier As String, ByVal ExtensionCible As String)

        If File.Exists(Fichier) Then
            Dim FichierSource As New FileStream(Fichier, FileMode.Open, FileAccess.Read)
            Dim FichierCible As New FileStream(Path.ChangeExtension(Fichier, ExtensionCible), _
 FileMode.Create, FileAccess.Write)
            Dim ChiffreFlux As New CryptoStream(FichierCible, STDES.CreateDecryptor, CryptoStreamMode.Write)
            FichierCible.SetLength(0)

            Dim Bin(100) As Byte
            Dim LongTotale As Long = FichierSource.Length
            RaiseEvent DebutChiffreEvent(Me, New ChiffreEventArgs(0, LongTotale))
            Dim LongEffectue As Long = 0
            Dim BlocLen As Integer

            'Traitement des données.
            While LongEffectue < LongTotale
                BlocLen = FichierSource.Read(Bin, 0, 100)
                ChiffreFlux.Write(Bin, 0, BlocLen)
                LongEffectue += BlocLen
                RaiseEvent ProgresChiffreEvent(Me, New ChiffreEventArgs(LongEffectue, LongTotale))
            End While

            RaiseEvent FinChiffreEvent(Me, New ChiffreEventArgs(LongEffectue, LongTotale))
            ChiffreFlux.Close()
            FichierSource.Close()
            FichierCible.Close()

        Else

            Throw New FileNotFoundException("Fichier introuvable", Fichier)

        End If

    End Sub

End Class
