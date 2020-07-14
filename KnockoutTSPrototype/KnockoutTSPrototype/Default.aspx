<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KnockoutTSPrototype._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Hello world</h1>




    <section class="content container-fluid">
        <div id="testManager">
            <div class="row">


                <p data-bind="text: myTest"></p>

            </div>
        </div>
    </section>



    <script type="text/javascript">


        var testViewModel;

        function TestViewModel() {
            var self = this;

            self.myTest = ko.observable('ahoj');

            self.init = function () {

            };

        }


        $(function () {

            console.log('ko init');

            if ($.isEmptyObject(testViewModel)) {
                testViewModel = new TestViewModel();
                ko.applyBindings(testViewModel, document.getElementById("testManager"));
                testViewModel.init();
            }
        });
    </script>

</asp:Content>
