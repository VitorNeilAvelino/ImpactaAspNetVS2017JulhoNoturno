var pesquisarButton = $("#pesquisarButton");

pesquisarButton.click(obterProdutoPorCategoria);

//$("#closePopover").click(fecharPopover);

$(document).on("click", "#closePopover", fecharPopover); //Brian Eich

function obterProdutoPorCategoria() {
    var categoriaId = $("#CategoriaId").val();

    //var retorno = $.ajax({
    //                url: "/Produtos/Categoria",
    //                method: "get", //type
    //                data: {categoriaId}
    //});

    //var x = retorno + 10;

    $.ajax({
        url: "/Produtos/Categoria",
        method: "get", //type
        data: { categoriaId }
    })
        .done(function (response) { exibirPopover(response) });
}

function exibirPopover(response) {
    pesquisarButton
        .popover("destroy")
        .popover({
            content: montarGridProdutos(response),
            html: true,
            animation: true,
            title: "Produtos desta categoria <span id='closePopover' class='close'>&times;</span>"
        })
        .popover("show");
}

function montarGridProdutos(produtos) {
    var html = "<table class='table table-striped'>";

    html += "<tr><th>Produto</th><th>Preço</th><th>Estoque</th></tr>";

    $(produtos).each(
        function (i) {
            html += "<tr>";
            html += "<td>" + produtos[i].Nome + "</td>";
            html += "<td>" + produtos[i].Preco.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }) + "</td>";
            html += "<td>" + produtos[i].Estoque + "</td>";
            html += "</tr>";
        }
    );

    return html + "</table>";
}

function fecharPopover() {
    pesquisarButton.popover("destroy");
}