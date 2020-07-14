<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="KnockoutTSPrototype.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    
    
    <h1>Hello world</h1>


    <section class="content container-fluid">

        <div id="aboutViewModelManager">
            
            
            <!-- Modal -->
            <div data-bind="modal: { visible: modalVisible, dialogCss: modalSize, header: { data: { label: headerData } }, body: { name: bodyTemplate, data: bodyData }, footer: { data: footerData } }">
                Here should be modal
            </div>

            
            
            <script type="text/html" id="aboutModalTemplate">
                <h2>Hello from modal</h2>
            </script>
            
            

            <div class="row">
                <div class="col-sm-6">
                    
                    
                    <p data-bind="text: aboutPageTitle"></p>
                    
                    
                    <a class="btn btn-primary" data-bind="click: openModal">
                        Open modal
                    </a>
                   
                </div>

            </div>
        </div>
    </section>
    
    
    <script type="text/javascript" src="ts/dist/about.js"></script>
    

</asp:Content>
