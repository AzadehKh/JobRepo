<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DesignGuide.ascx.cs"
    Inherits="JobRepo.User_Controls.DesignGuide" %>


    <%@ OutputCache  VaryByParam="none" duration="31536000"%>

<script src="~/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="~/Scripts/jquery-blink.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {


        $("#MainContent_MainContent_desgingd_btnShow").click(Show);
        //Each master page has different name for this control
        //From Administration/Administration.master
        $("#desgingd_btnShow").click(Show);
        //From site.master
        $("#MainContent_desgingd_btnShow").click(Show);

        function Show(event) {


            if ($(this).attr("value") == "Read about me") {
                $("#gd").show("slow");
                $(this).attr("value", "Close");
            }
            else {
                $(this).attr("value", "Read about me");
                $("#gd").hide("slow");

            }
        }

    });
</script>
<input type="button" id="btnShow" runat="server" value="Read about me" />
<div id="gd" style="display: none">
    <asp:Panel ID="Panel1" runat="server" BorderWidth="3" Wrap="true">
        <asp:Literal ID="litContent" runat="server"></asp:Literal>
    </asp:Panel>
</div>
