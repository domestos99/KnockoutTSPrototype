<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KnockoutTSPrototype._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Hello world</h1>


    <section class="content container-fluid">
        <div id="testManager">
            <div class="row">
                <div class="col-sm-6">
                    
                    <input type="text" data-bind="value: searchName" />
                    Search text: <b data-bind="text: searchName"></b>
                    
                    <a class="btn btn-primary"
                       data-bind="click: search">Search</a>

                    
                    <hr />

                    Počet:
                    <p data-bind="text: partner().length"></p>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>name</th>
                                <th>City</th>
                            </tr>
                        </thead>
                        <tbody data-bind="foreach: partner">
                            <tr>
                                <td>
                                    <input type="text" data-bind="value: name" />

                                </td>
                                <td data-bind="text: name"></td>
                                <td data-bind="text: city"></td>
                            </tr>
                        </tbody>
                    </table>
                </div>

            </div>
        </div>
    </section>


    <script type="text/javascript" src="ts/dist/app.js"></script>

</asp:Content>
