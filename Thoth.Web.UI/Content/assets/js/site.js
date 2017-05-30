
function getDataTableLanguage() {
    return {
        "metronicGroupActions": "_TOTAL_ records selected:  ",
        "metronicAjaxRequestGeneralError": "İsteğiniz gerçekleştirilemedi. Lütfen internet bağlantınızı kontrol ediniz",
        "lengthMenu": "<span class='seperator'>|</span>Sayfada _MENU_ Kayıt Göster",
        "info": "<span class='seperator'>|</span>Toplam _TOTAL_ kayıt bulundu",
        "infoEmpty": "Gösterilebilecek kayıt bulunamadı",
        "emptyTable": "Kayıt Bulunamadı",
        "zeroRecords": "Eşleşen kayıt bulunamadı",
        "paginate": {
            "previous": "Önceki",
            "next": "Sonraki",
            "last": "Son",
            "first": "İlk",
            "page": "Sayfa",
            "pageOf": "<span class='seperator'>|</span>Toplam Sayfa"
        }
    };
}

function toJSDateTime(jsonDate) {

    var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
    var month = (date.getMonth() + 1) > 9 ? (date.getMonth() + 1) : "0" + (date.getMonth() + 1);
    var day = (date.getDate()) > 9 ? (date.getDate()) : "0" + (date.getDate());
    //var hours = (date.getHours()) > 9 ? (date.getHours()) : "0" + (date.getHours());
    //var minutes = (date.getMinutes()) > 9 ? (date.getMinutes()) : "0" + (date.getMinutes());

    return day + "." + month + "." + date.getFullYear();

}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    console.log(charCode);
    if (charCode >= 96 && charCode <= 105) return true;
    else if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) return false;
    else return true;
}

function textareaCounter(field, feedback, maxlimit) {

    var x = field.value;

    var newLines = x.match(/(\r\n|\n|\r)/g);
    var addition = 0;
    if (newLines != null) {
        addition = newLines.length;
    }

    if ((x.length + addition) > maxlimit) {
        field.value = field.value.substring(0, (maxlimit - addition));

        x = field.value;

        newLines = x.match(/(\r\n|\n|\r)/g);
        addition = 0;
        if (newLines != null) {
            addition = newLines.length;
        }
    }

    $('#length').html(x.length + addition);
    $('#' + feedback).html("Kalan Karakter " + (maxlimit - (x.length + addition)));

}

function IsMobile() {
    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
        $.mCustomScrollbar.defaults.scrollButtons.enable = false;
        //$.mCustomScrollbar.defaults.axis="yx"; //enable 2 axis scrollbars by default

        $("#scrollable-content").mCustomScrollbar({
            axis: "x",
            setHeight: 'auto',
            setWidth: "auto",
            theme: "dark",
            advanced: {
                updateOnContentResize: true
            }
        });

    }
}

function InputMask() {
    $(".decimal").inputmask("decimal", {
        radixPoint: ",",
        digits: 2,
        autoGroup: true,
        removeMaskOnSubmit: true,
        autoUnmask: true,
        showMaskOnHover: false,
        showMaskOnFocus: false,
        greedy: false
    });


    $(".currency").inputmask("decimal", {
        radixPoint: ",",
        groupSeparator: ".",
        digits: 2,
        autoGroup: true,
        removeMaskOnSubmit: true,
        autoUnmask: true,
        showMaskOnHover: false,
        showMaskOnFocus: false,
        greedy: false
    });
    $(".currency_tl").inputmask("decimal", {
        radixPoint: ",",
        groupSeparator: ".",
        digits: 2,
        autoGroup: true,
        prefix: '₺',
        removeMaskOnSubmit: true,
        autoUnmask: true,
        showMaskOnHover: false,
        showMaskOnFocus: false,
        greedy: false
    });

    $(".currency_tl").inputmask("decimal", {
        radixPoint: ",",
        groupSeparator: ".",
        digits: 2,
        autoGroup: true,
        prefix: '₺',
        autoUnmask: true,
        showMaskOnHover: false,
        showMaskOnFocus: false,
        greedy: false
    });

    $(".currency_dollar").inputmask("decimal", {
        radixPoint: ",",
        groupSeparator: ".",
        digits: 2,
        autoGroup: true,
        prefix: '$',
        removeMaskOnSubmit: true,
        autoUnmask: true,
        showMaskOnHover: false,
        showMaskOnFocus: false,
        greedy: false
    });

    $(".numeric_input").inputmask("mask", {
        "mask": "9",
        "repeat": 11,
        "greedy": false
    });

    $(".phone").inputmask("mask", { "mask": "(999) 999-9999" });

}