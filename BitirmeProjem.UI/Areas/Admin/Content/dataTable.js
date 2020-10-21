var DataTableAjax = function () {
    var datatable;
    var myTable = function (url, columns, confirmFunc, confirmParams) {
        datatable = $('.m_datatable').mDatatable({
            // datasource definition
            data: {
                type: 'remote',
                source: {
                    read: {
                        // sample GET method
                        method: 'POST',
                        url: url,
                        map: function (raw) {
                            // sample data mapping
                            var dataSet = raw;
                            if (typeof raw.data !== 'undefined') {
                                dataSet = raw.data;
                            }
                            return dataSet;
                        }
                    }
                },
                pageSize: 10,
                perpage: 10,
                serverPaging: true,
                serverFiltering: true,
                serverSorting: true
            },

            // layout definition
            layout: {
                scroll: false,
                footer: false
            },
            search: {
                input: $('#generalSearch')
            },


            // columns definition
            columns: columns
        });
        $(datatable).on("click", "td button.btn-confirm", function (e) {
            var dataID = $(this).attr('data-id');
            console.log(dataID);
            swal({
                title: 'Silinsin mi?',
                text: "Kaydı silmek istediğinizden emin misiniz!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Evet'
            }).then(function (result) {
                if (result.value) {
                    if (confirmFunc != undefined) {
                        confirmParams.id = dataID;
                        confirmFunc(confirmParams);
                    }
                }
            });
        });
    };

   
    return {
        init: function (url, columns, confirmFunc, confirmParams) {
            myTable(url, columns, confirmFunc, confirmParams);
           
        },
        refresh: function () {
            datatable.reload();
        },
        reload: function (url, columns, confirmFunc, confirmParams) {
            console.log(datatable);
            datatable.destroy();
            myTable(url, columns, confirmFunc, confirmParams);
            //datatable.reload(url);
        }
    }
}();

function getDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getDate()) + "/" + (dt.getMonth()+1) + "/" + dt.getFullYear();
}
function getStatu(value) {
    if (value==1) {
        return "<span class='m-badge  m-badge--success  m-badge--wide m-badge--rounded'>Yeni</span>";
    } else if(value==2) {
        return "<span class='m-badge m-badge--danger m-badge--wide m-badge--rounded'>Kargolandı</span>";
    }
}
function getType(value) {
    if (value==1) {
        return "Kapıda Ödemeli";
    }
    else if (value == 2) {
        return "Banka Havalesi veya Eft Ödemeli";
    }
    else if (value==3) {
        return "Özel Tasarım";
    }
}
function getSum(value) {
    if (value==1) {
        return "1 Takım";
    }
    else if (value==2) {
        return "1 Adet";
    }
}
function getPayStatu(value) {
    console.log(value);
    if (value==1) {
        return "Yapıldı";
    } else {
        return "Yapılmadı";
    }
}
function getPayMethod(value) {
    if (value == 1) {
        return "Kredi Kartı";
    }
    else if (value == 2) {
        return "Havale";
    }
    else if (value == 3) {
        return "Kapıda Ödeme";
    } else {
        return "Bilinmiyor.";
    }
}
function getName(row) {
    return row.Name + ' ' + row.LastName;
}