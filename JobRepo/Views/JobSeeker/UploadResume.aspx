<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Independent.Site.Master" 
Inherits="System.Web.Mvc.ViewPage<JobRepo.Model.FileModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

	UploadResume
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm("UploadResume", "JobSeeker", FormMethod.Post, new { enctype = "multipart/form-data" }))
       {%>
        <fieldset>
            <legend>UploadResume</legend>
            <p>
              Title:
              <%: Html.TextBoxFor(model => model.Title) %>
              </p>
            <p>
              Skills:
              <%: Html.TextBoxFor(model => model.Keywords) %>
              <br/>
              Please enter some tags or keywords to make your resume searchable by JobRepo Search Engine 
              </p>
               <div class="editor-label">
                <%: Html.LabelFor(model => model.File.FileName) %>
            </div>
             <div class="editor-field">
             <%-- Strong typed --%>
             <%--   <%= Html.FileUploader((Model != null ? Model.File : null)) %>--%>
             <%-- Non-Strong typed      --%>
                <%= Html.FileUploader(m => m.File, new { type = "file" })%>
                <%: Html.ValidationMessageFor(model => model.File) %>
            </div>

            <p>
                <input type="submit" value="Submit" />
            </p>
       </fieldset>
         <%: Html.ValidationSummary(false) %>
    <% } %>

</asp:Content>
