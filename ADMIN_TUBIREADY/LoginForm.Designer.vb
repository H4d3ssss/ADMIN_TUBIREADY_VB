<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        pnlMain = New Guna.UI2.WinForms.Guna2Panel()
        pnlLogin = New Guna.UI2.WinForms.Guna2Panel()
        Label5 = New Label()
        btnLogin = New Guna.UI2.WinForms.Guna2Button()
        Guna2TextBox2 = New Guna.UI2.WinForms.Guna2TextBox()
        Guna2TextBox1 = New Guna.UI2.WinForms.Guna2TextBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(components)
        pnlMain.SuspendLayout()
        pnlLogin.SuspendLayout()
        CType(Guna2PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlMain
        ' 
        pnlMain.Controls.Add(pnlLogin)
        pnlMain.CustomBorderThickness = New Padding(0, 20, 0, 0)
        pnlMain.CustomizableEdges = CustomizableEdges11
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(0, 0)
        pnlMain.Name = "pnlMain"
        pnlMain.ShadowDecoration.CustomizableEdges = CustomizableEdges12
        pnlMain.ShadowDecoration.Depth = 10
        pnlMain.ShadowDecoration.Enabled = True
        pnlMain.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        pnlMain.ShadowDecoration.Shadow = New Padding(0, 0, 0, 5)
        pnlMain.Size = New Size(493, 634)
        pnlMain.TabIndex = 0
        ' 
        ' pnlLogin
        ' 
        pnlLogin.BackColor = Color.Transparent
        pnlLogin.BorderColor = Color.Silver
        pnlLogin.BorderRadius = 50
        pnlLogin.BorderThickness = 1
        pnlLogin.Controls.Add(Label5)
        pnlLogin.Controls.Add(btnLogin)
        pnlLogin.Controls.Add(Guna2TextBox2)
        pnlLogin.Controls.Add(Guna2TextBox1)
        pnlLogin.Controls.Add(Label4)
        pnlLogin.Controls.Add(Label3)
        pnlLogin.Controls.Add(Label2)
        pnlLogin.Controls.Add(Label1)
        pnlLogin.Controls.Add(Guna2PictureBox1)
        pnlLogin.CustomBorderColor = Color.FromArgb(CByte(4), CByte(102), CByte(200))
        pnlLogin.CustomBorderThickness = New Padding(0, 10, 0, 0)
        pnlLogin.CustomizableEdges = CustomizableEdges9
        pnlLogin.FillColor = Color.White
        pnlLogin.Font = New Font("Calibri", 15.75F, FontStyle.Bold)
        pnlLogin.Location = New Point(0, 0)
        pnlLogin.Name = "pnlLogin"
        pnlLogin.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        pnlLogin.ShadowDecoration.Depth = 5
        pnlLogin.ShadowDecoration.Enabled = True
        pnlLogin.ShadowDecoration.Shadow = New Padding(0, 0, 5, 5)
        pnlLogin.Size = New Size(492, 634)
        pnlLogin.TabIndex = 0
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        Label5.Location = New Point(188, 587)
        Label5.Name = "Label5"
        Label5.Size = New Size(107, 15)
        Label5.TabIndex = 8
        Label5.Text = "TubiReady © 2025"
        ' 
        ' btnLogin
        ' 
        btnLogin.BorderRadius = 25
        btnLogin.CustomizableEdges = CustomizableEdges1
        btnLogin.DisabledState.BorderColor = Color.DarkGray
        btnLogin.DisabledState.CustomBorderColor = Color.DarkGray
        btnLogin.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnLogin.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnLogin.FillColor = Color.FromArgb(CByte(4), CByte(102), CByte(200))
        btnLogin.Font = New Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(61, 539)
        btnLogin.Name = "btnLogin"
        btnLogin.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnLogin.Size = New Size(363, 45)
        btnLogin.TabIndex = 7
        btnLogin.Text = "Mag-Login"
        ' 
        ' Guna2TextBox2
        ' 
        Guna2TextBox2.CustomizableEdges = CustomizableEdges3
        Guna2TextBox2.DefaultText = ""
        Guna2TextBox2.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        Guna2TextBox2.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        Guna2TextBox2.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        Guna2TextBox2.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        Guna2TextBox2.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Guna2TextBox2.Font = New Font("Calibri", 12F, FontStyle.Bold)
        Guna2TextBox2.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Guna2TextBox2.IconLeft = CType(resources.GetObject("Guna2TextBox2.IconLeft"), Image)
        Guna2TextBox2.IconLeftOffset = New Point(15, 0)
        Guna2TextBox2.IconLeftSize = New Size(25, 25)
        Guna2TextBox2.Location = New Point(54, 430)
        Guna2TextBox2.Margin = New Padding(3, 4, 3, 4)
        Guna2TextBox2.Name = "Guna2TextBox2"
        Guna2TextBox2.PlaceholderText = "Enter your Password"
        Guna2TextBox2.SelectedText = ""
        Guna2TextBox2.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Guna2TextBox2.Size = New Size(370, 57)
        Guna2TextBox2.TabIndex = 6
        ' 
        ' Guna2TextBox1
        ' 
        Guna2TextBox1.CustomizableEdges = CustomizableEdges5
        Guna2TextBox1.DefaultText = ""
        Guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        Guna2TextBox1.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        Guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        Guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        Guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Guna2TextBox1.Font = New Font("Calibri", 12F, FontStyle.Bold)
        Guna2TextBox1.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Guna2TextBox1.IconLeft = CType(resources.GetObject("Guna2TextBox1.IconLeft"), Image)
        Guna2TextBox1.IconLeftOffset = New Point(10, 0)
        Guna2TextBox1.IconLeftSize = New Size(25, 25)
        Guna2TextBox1.Location = New Point(54, 319)
        Guna2TextBox1.Margin = New Padding(3, 4, 3, 4)
        Guna2TextBox1.Name = "Guna2TextBox1"
        Guna2TextBox1.PlaceholderText = "Enter your Username"
        Guna2TextBox1.SelectedText = ""
        Guna2TextBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        Guna2TextBox1.Size = New Size(370, 57)
        Guna2TextBox1.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Calibri", 15.75F, FontStyle.Bold)
        Label4.Location = New Point(54, 400)
        Label4.Name = "Label4"
        Label4.Size = New Size(94, 26)
        Label4.TabIndex = 4
        Label4.Text = "Password"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Calibri", 15.75F, FontStyle.Bold)
        Label3.Location = New Point(54, 289)
        Label3.Name = "Label3"
        Label3.Size = New Size(101, 26)
        Label3.TabIndex = 3
        Label3.Text = "Username"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Calibri", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.FromArgb(CByte(104), CByte(94), CByte(94))
        Label2.Location = New Point(111, 192)
        Label2.Name = "Label2"
        Label2.Size = New Size(275, 59)
        Label2.TabIndex = 2
        Label2.Text = "Admin Login"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Gadugi", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(111, 142)
        Label1.Name = "Label1"
        Label1.Size = New Size(260, 19)
        Label1.TabIndex = 1
        Label1.Text = "Maging Alerto, Manatiling Ligtas"
        ' 
        ' Guna2PictureBox1
        ' 
        Guna2PictureBox1.CustomizableEdges = CustomizableEdges7
        Guna2PictureBox1.Image = My.Resources.Resources.SYS_LOGO
        Guna2PictureBox1.ImageRotate = 0F
        Guna2PictureBox1.Location = New Point(69, 63)
        Guna2PictureBox1.Name = "Guna2PictureBox1"
        Guna2PictureBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        Guna2PictureBox1.Size = New Size(350, 76)
        Guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        Guna2PictureBox1.TabIndex = 0
        Guna2PictureBox1.TabStop = False
        ' 
        ' Guna2Elipse1
        ' 
        Guna2Elipse1.BorderRadius = 100
        Guna2Elipse1.TargetControl = Me
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(493, 634)
        Controls.Add(pnlMain)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login Form"
        pnlMain.ResumeLayout(False)
        pnlLogin.ResumeLayout(False)
        pnlLogin.PerformLayout()
        CType(Guna2PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlMain As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents pnlLogin As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Guna2TextBox2 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2TextBox1 As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnLogin As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Label5 As Label
End Class
