<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Settimana_15_Esercizio_4.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
</head>
<body>
    <div class="bg-primary px-5 py-2">
        <p class="display-5 text-warning mb-0">LeleAuto's</p>
    </div>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-4">
                    <div class="p-3 pe-2 border-bottom border-end border-primary rounded-bottom">
                        <p class="display-6">Seleziona Auto</p>
                        <ul class="list-group" id="ListOfCars" runat="server">
                        </ul>
                    </div>
                </div>

                <div class="col-8">
                    <div id="dettagliAuto" runat="server" class="ps-2 p-3">
                        <p id="prezzoBase" runat="server"></p>
                    </div>
                </div>
            </div>
            <div id="optional" runat="server" visible="false">
                <p class="display-6">Seleziona gli optional, puoi selezionarne più di uno</p>
                <div class="d-flex flex-wrap" id="optionalCheck" runat="server"></div>
            </div>
            <div id="garazia" runat="server" visible="false">
                <p class="display-6">Seleziona il numero di anni di garanzia</p>
                <p>Ogni anno costa 120€</p>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="radio" name="Garanzia" id="UnAnno" value="1"/>
                    <label class="form-check-label" for="UnAnno">1</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="radio" name="Garanzia" id="DueAnni" value="2"/>
                    <label class="form-check-label" for="DueAnni">2</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="radio" name="Garanzia" id="TreAnni" value="3"/>
                    <label class="form-check-label" for="TreAnni">3</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="radio" name="Garanzia" id="QuattroAnni" value="4"/>
                    <label class="form-check-label" for="QuattroAnni">4</label>
                </div>
            </div>
            <div id="recapDiv" runat="server" visible="false" class="mt-3">
                <asp:Button ID="recap" runat="server" Text="Conferma" CssClass="btn btn-primary" onClick="Recap_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
