<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>asdasd</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main" runat="server">
    <asp:Label runat="server" id="HelloWorldLabel"></asp:Label>
    <br /><br />
    <asp:TextBox runat="server" id="TextInput" /> 
    <asp:Button runat="server" id="idButton" OnClick="findIdStudent" Text="FIND BY ID"/>
    <asp:Button runat="server" ID="nameButton" OnClick="findNameStudent" Text="FIND BY NAME" />
    <asp:Button runat="server" ID="allButton" OnClick="findAllStudent" Text="FIND ALL"/>
    <div id ="tab" runat="server">
        <asp:Repeater ID="tabrep" runat="server" OnItemCommand="tabrep_OnItemCommand">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>
                            ID
                        </th>
                        <th>
                            Name
                        </th>
                        <th>
                            Last name
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="id_label" Text='<%# DataBinder.Eval(Container.DataItem, "id" )%>' />
                    </td>
                    <td>
                        <asp:TextBox ID="name_txt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "name")%>' />
                    </td>
                    <td>
                        <asp:TextBox ID="last_name_txt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "last_name")%>' />
                    </td>
                    <td>
                        <asp:Button runat="server" CommandName="Save" Text="Save"/>
                    </td>
                    <td>
                        <asp:Button runat="server" CommandName="Delete" Text="Delete" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br/>
        <h2>Insert new student</h2>
        <asp:TextBox ID="insStudent_name" runat="server" />
        <asp:TextBox ID="insStudent_lname" runat="server" />
        <asp:Button ID="insStudBtn" runat="server" Text="Insert" OnClick="insertStudent"/>
    </div>
    </div>
    </form>
</body>
</html>
