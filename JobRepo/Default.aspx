<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="JobRepo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td style="width: 33%;">
                <b style="font-size: large; color: #0000FF; font-weight: bold">Employers</b>
                <div style="border: medium solid #000080; ">
                    <a href="EmployerProfile.aspx"> My Profile </a>
                    <br />
                     <a href="JobList.aspx"> My Jobs </a>
                     <br />
                      <a href="JobAdv.aspx"> Active Job Advertisements </a>
                      <br /> 
                     <a href="Employer/SeekEmployee"> Employee Search </a>
                     <br />
                      <a href="SelectedEmployee/List"> Selected Employee(s) </a>
                      <br /> 
                      
                      <br />
                </div>
                &nbsp;
            </td>
            <td style="width: 34%;">
                <b style="font-size: large; color: #0000FF; font-weight: bold">Job Seekers</b>
                <div style="border: medium solid #000080">
                     <a href="JobSearch.aspx">Job Search </a>
                     <br />
                     <a href="JobSeeker/CreateProfile">My Profile </a>
                     <br />
                     <a href="JobSeeker/ManageResumes">My Resumes </a>
                     <br />
                     <br />

                </div>
                &nbsp;
            </td>
            <td style="width: 33%;">
                <b style="font-size: large; color: #0000FF; font-weight: bold">Your Account</b>
                <div style="border: medium solid #000080">
                     <a href="Account/Register.aspx"> Register </a>
                     <br />
                          <a href="Account/Login.aspx"> Login </a>
                          <br />
                          <br />

                          <br />
                </div>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
