$(function () {
    $("#add").click(function (e) {
        e.preventDefault();

        var i = $(".items").length;

        var y = `
        <div class="card mb-4">
            <div class="card-body">
                <h3 class="h6">Equipment</h3>
                   <div class="field-input-data">
                        <label>Name of equipment</label>
                        <input  style="margin-bottom: 5px; border-color: #DDDDDD; border-radius: 5px" type="text" class="items" name="Equipments[` + i + `].Name" />
                    </div>
            </div>
        </div>`;
        $("#item-list").append(y);
    });

});