let dataTable;
loadDataTable();

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Company/Flight/GetAll"
        },
        "columns": [
            {"data":"departure"},
            {"data":"arrival"},
            {"data":"economyPrice"},
            {"data":"businessPrice"},
            {"data":"formattedFrom"},
            {"data":"formattedTo"},
            {"data":"airline"}
        ]
    })
}