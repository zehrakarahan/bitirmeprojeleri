//== Class definition

var DatatableRemoteAjaxDemo = function () {
    //== Private functions

    // basic demo
    var myTable = function (url, columns) {
       
        var datatable = $('.m_datatable').mDatatable({
            // datasource definition
            data: {
                type: 'remote',
                source: {
                    read: {
                        // sample GET method
                        method: 'POST',
                        url: '/Messages/List',
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
                pageSize: 5,
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
            columns: [
              {
                  field: 'ID',
                  title: '#',
                  width: 40,
                  textAlign: 'center',
                  template: function (row, index, datatable) {
                      return (index + 1);
                  }
              }, {
                  field: 'Name',
                  title: 'Adı'
              }, {
                  field: 'SurName',
                  title: 'Soyadı'
              }, {
                  field: 'Email',
                  title: 'E-Mail'
              }, {
                  field: 'PhoneNumber',
                  title: 'Telefon'
              }, {
                  field: 'MessageDate',
                  title: 'Tarih',
                  template: function (row, index, datatable) {
                      return getDate(row.MessageDate);
                  }
              }, {
                  field: 'Actions',
                  width: 110,
                  title: 'Actions',
                  "sortable": false,
                  template: function (row, index, datatable) {
                      return '\
						<a href="/Admin/Messages/Detail/'+ row.ID + '" class="m-portlet__nav-link btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" title="Düzenle">\
							<i class="la la-edit"></i>\
						</a>\
						<button  class="m-portlet__nav-link btn m-btn m-btn--hover-danger m-btn--icon m-btn--icon-only m-btn--pill btn-confirm" data-title="Emin misiniz?" data-toggle="confirmation"   data-id="5">\
							<i class="la la-trash"></i>\
						</button>\
					';
                  }
              }]
        });
        $(datatable).one('m-datatable--on-layout-updated', function () {
            $('[data-toggle=confirmation]').confirmation({
                rootSelector: '[data-toggle=confirmation]',
                onConfirm: function () {
                    sil($(this).attr('data-id'));
                }
                // other options
            });
        });
    };

    return {
        // public functions
        init: function (url,columns) {
            myTable(url,columns);
        }
    };
}();

jQuery(document).ready(function () {
    DatatableRemoteAjaxDemo.init('murat','selam');
});
function getDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getDate() + 1) + "/" + dt.getMonth() + "/" + dt.getFullYear();
}