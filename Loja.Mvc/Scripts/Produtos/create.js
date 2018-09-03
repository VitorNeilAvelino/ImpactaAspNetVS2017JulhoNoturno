var pesquisarButton = $("#pesquisarButton");

pesquisarButton.click(obterProdutoPorCategoria);

$(document).on("click", "#fecharPopover", fecharPopover);

function obterProdutoPorCategoria() {
    const categoriaId = $("#CategoriaId").val();

    if (!categoriaId || pesquisarButton.next('div.popover:visible').length) {
        fecharPopover();
        return;
    }

    $.ajax({
        url: "/Produtos/Categoria",
        method: "GET",
        data: { categoriaId }
    }
    )
        .done(function (response) { exibirPopover(response); })
        .fail()
        .always();
}

function exibirPopover(response) {
    pesquisarButton
        .popover("destroy")
        .popover({
            content: montarGridProdutos(response),
            html: true,
            animation: true,
            title: "Produtos desta categoria <span class='close' id='fecharPopover'>&times;</span>"
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