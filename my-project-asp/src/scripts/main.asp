 <%
 Response.Write("Welcome to the Employer Portal")
 Dim username
 username = Request("username")
 ' Potential SQL Injection vulnerability
 sql = "SELECT * FROM users WHERE username = '" & username & "'"

' Check if the username exists in the simulated database
If users.Exists(username) Then
    Response.Write("Hello, " & users(username))
Else
    Response.Write("User not found.")
End If
 Ser rs = conn.Execute(sql)
 If Not rs.EOF Then
     Response.Write("Hello, " & rs("name"))
 Else
     Response.Write("User not found.")
 End If
 %>