let dataTable;
loadDataTable();

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Company/Ticket/GetAll"
        },
        "columns": [
            {"data":"purchaseDate"},
            {"data":"price"},
            {"data":"seatClass"},
            {"data":"position"}
        ]
    })
}