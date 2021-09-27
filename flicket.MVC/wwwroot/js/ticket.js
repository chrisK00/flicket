let dataTable;
console.log('hello');
loadDataTable();

function loadDataTable() {
    console.log('hello');

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