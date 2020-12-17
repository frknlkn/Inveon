$("#LoadingStatus").html("Loading....");
$.get("/Account/GetAdresler", null, DataBind);
function DataBind(Adresler) {
    //This Code For Receive All Data From Controller And Show It In Client Side
    var SetData = $("#SetAdresler");
    for (var i = 0; i < Adresler.length; i++) {
        var Data =
            "<div class='col-lg-6 col-md-6 col-xs-6  marginb-20 address-section'>" +
            "<div class='titleBox'>" +
            "<span class='title'>" + Adresler[i].AdresBasligi + "</span>" +
            "<span class='edit' onclick='EditAddress(" + Adresler[i].Id + ")'>" + 'Düzenle' + "</span>" +
            "<span class='delete' onclick='DeleteAddress(" + Adresler[i].Id + ")'></span>" +
            "</div>" +
            "<div class='addressInfoBox'>" +
            "<label>" +
            "<span class='username'>" + Adresler[i].Ad + " " + Adresler[i].Soyad + "</span>" +
            "<div class='Address-line-1'>" + Adresler[i].Adres + "</div>" +
            "<div class='Address-line-2'></div>" +
            "<div class='address'></div>" +
            "<div class='location'>" + Adresler[i].Il + " - " + Adresler[i].Ilce + "</div>" +
            "<div class='tel'>" + Adresler[i].CepTelefonu + "</div>" +
            "</label>" +
            "</div>" +
            "</div>";
        SetData.append(Data);
        $("#LoadingStatus").html(" ");

    }
}
function AddNewAddress(Id) {
    $("#form")[0].reset();
    $("#Id").val(0);
    $("#ModalTitle").html("Adres Ekle");
    $("#MyModal").modal();
}
function EditAddress(Id) {
    var url = "/Account/GetAdressById/" + Id;
    $("#ModalTitle").html("Adres Güncelle");
    $("#MyModal").modal();
    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            var obj = JSON.parse(data);
            $("#Id").val(obj.Id);
            $("#Ad").val(obj.Ad);
            $("#Soyad").val(obj.Soyad);
            $("#CepTelefonu").val(obj.CepTelefonu);
            $("#Il").val(obj.Il);
            $("#Ilce").val(obj.Ilce);
            $("#Adres").val(obj.Adres);
            $("#AdresBasligi").val(obj.AdresBasligi);
        }
    });
}
$("#UpdateAddressForm").click(function () {
    var data = $("#SubmitForm").serialize();
    $.ajax({
        type: "Post",
        url: "/Account/SaveDataInDatabase",
        data: data,
        success: function (result) {
            if (result == true) {
                $("#MyModal").modal("hide");
                Swal.fire(
                    'Adres Kaydedildi',
                    'Devam etmek için butona basınız!',
                    'success'
                );
                $("#SetAdresler").html("");
                $.get("/Account/GetAdresler", null, DataBind);
            } else {
                $("#MyModal").modal("hide");
                Swal.fire({
                    type: 'error',
                    title: 'Hata!..',
                    text: 'Eksik veya hatalı bilgi girdiniz!',
                    footer: 'Lütfen Tekrar deneyiniz..'
                });
            }
        }
    });
});

function DeleteAddress(Id) {
    $("#Id").val(Id);
    $("#DeleteConfirmation ").modal("show");
}

function ConfirmDelete() {
    var Id = $("#Id").val();
    $.ajax({
        type: "POST",
        url: "/Account/DeleteAddressRecord?Id=" + Id,
        success: function (result) {
            $("#DeleteConfirmation ").modal("hide");
            $(".row_" + Id).remove();
        }
    });
    $("#SetAdresler").html("");
    $.get("/Account/GetAdresler", null, DataBind);
}
