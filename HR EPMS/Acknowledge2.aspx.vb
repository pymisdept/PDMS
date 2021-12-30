Partial Public Class Acknowledge2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Session("P2BREF") IsNot Nothing Then

            Else
                Response.Redirect("Phase2Main.aspx")
            End If
        End If
    End Sub

End Class