Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Function GetGroupNumber(ByVal str As String) As Integer
		str = str.ToLower()
		Dim ch As Char = str.Chars(0)
		Dim i As Integer = Convert.ToInt32(ch)

		If ch >= "a"c AndAlso ch <= "e"c Then
			Return 1
		End If
		If ch >= "f"c AndAlso ch <= "j"c Then
			Return 2
		End If
		If ch >= "k"c AndAlso ch <= "q"c Then
			Return 3
		End If
		If ch >= "r"c AndAlso ch <= "v"c Then
			Return 4
		End If
		If ch >= "x"c AndAlso ch <= "z"c Then
			Return 5
		End If

		Return -1
	End Function

	Protected Sub grid_CustomColumnGroup(ByVal sender As Object, ByVal e As DevExpress.Web.CustomColumnSortEventArgs)
		If e.Column.Name <> "VisibleProductName" Then
			Return
		End If

		Dim res1 As Integer = GetGroupNumber(e.GetRow1Value(e.Column.FieldName).ToString())
		Dim res2 As Integer = GetGroupNumber(e.GetRow2Value(e.Column.FieldName).ToString())

		Dim res As Integer = res1 - res2

		If res < 0 Then
			res = 1
		ElseIf res > 0 Then
			res = -1
		End If

		e.Result = res
		e.Handled = True
	End Sub

	Protected Sub grid_CustomGroupDisplayText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs)
		Dim ind As Integer = GetGroupNumber(e.Value.ToString())
		Select Case ind
			Case 1
				e.DisplayText = "A-E"
			Case 2
				e.DisplayText = "F-J"
			Case 3
				e.DisplayText = "K-Q"
			Case 4
				e.DisplayText = "R-V"
			Case 5
				e.DisplayText = "X-Z"
		End Select
	End Sub

	Protected Sub grid_BeforeColumnSortingGrouping(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs)
		If e.Column.Name = "VisibleProductName" Then
			grid.Columns("InvisibleProductName").Visible = ((TryCast(grid.Columns("VisibleProductName"), GridViewDataColumn)).GroupIndex <> -1)
		End If
	End Sub
End Class
