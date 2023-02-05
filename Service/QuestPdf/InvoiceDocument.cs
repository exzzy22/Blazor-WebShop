namespace Service.QuestPdf;

public class InvoiceDocument : IDocument
{
	public Order Model { get; }

	public InvoiceDocument(Order model)
	{
		Model = model;
	}

	public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

	public void Compose(IDocumentContainer container)
	{
		container
			.Page(page =>
			{
				page.Margin(50);

				page.Header().Element(ComposeHeader);
				page.Content().Element(ComposeContent);

				page.Footer().AlignCenter().Text(text =>
				{
					text.CurrentPageNumber();
					text.Span(" / ");
					text.TotalPages();
				});
			});
	}

	void ComposeHeader(IContainer container)
	{
		container.Row(row =>
		{
			row.RelativeItem().Column(Column =>
			{
				Column
					.Item().Text($"Invoice #{string.Format("{0:00000}", Model.Id)}")
					.FontSize(20).SemiBold().FontColor(Colors.Black);

				Column.Item().Text(text =>
				{
					text.Span("Date of issue: ").SemiBold();
					text.Span($"{Model.CratedDate.ToString("dd.MM.yyyy")}");
				});
			});

			row.ConstantItem(100).Height(50).Placeholder();
		});
	}

	void ComposeContent(IContainer container)
	{
		container.PaddingVertical(20).Column(column =>
		{
			column.Spacing(20);

			column.Item().Row(row =>
			{
				row.ConstantItem(270);
				row.RelativeItem().Column(column =>
				{
					column.Item().Text("Company Inc.");
					column.Item().Text("4628 Waterview Lane");
					column.Item().Text($"Kenton, New Mexico");
					column.Item().Text("email@mail.com");
					column.Item().Text("505-451-8039");
				});
			});

			column.Item().Row(row =>
			{
				row.RelativeItem().Component(new AddressComponent("Billing Address", Model.BillingAddress));
				row.ConstantItem(50);
				row.RelativeItem().Component(new AddressComponent("Shipping Address", Model.ShippingAddress));
			});

			column.Item().Element(ComposeTable);

			column.Item().PaddingRight(5).AlignRight().Text($"Total: {Model.Amount.ToString("N2")} {Model.Prodcuts.First().CurrencySymbol}").SemiBold();

			if (!string.IsNullOrWhiteSpace(Model.Note))
				column.Item().PaddingTop(25).Element(ComposeComments);
		});
	}

	void ComposeTable(IContainer container)
	{
		var headerStyle = TextStyle.Default.SemiBold();

		container.Table(table =>
		{
			table.ColumnsDefinition(columns =>
			{
				columns.ConstantColumn(25);
				columns.RelativeColumn(3);
				columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
				columns.RelativeColumn();
			});

			table.Header(header =>
			{
				header.Cell().Text("#");
				header.Cell().Text("Product").Style(headerStyle);
				header.Cell().AlignRight().Text("Unit price").Style(headerStyle);
                header.Cell().AlignRight().Text("Discount").Style(headerStyle);
                header.Cell().AlignRight().Text("Quantity").Style(headerStyle);
				header.Cell().AlignRight().Text("Total").Style(headerStyle);

				header.Cell().ColumnSpan(6).PaddingTop(5).BorderBottom(1).BorderColor(Colors.Black);
			});

			List<ProductOrder> products = Model.Prodcuts.ToList();

			foreach (var product in products)
			{
				int index = products.IndexOf(product) + 1;

				table.Cell().Element(CellStyle).Text($"{index}");
				table.Cell().Element(CellStyle).Text(product.Name);
				table.Cell().Element(CellStyle).AlignRight().Text($"{product.Price.ToString("N2")} {product.CurrencySymbol}");
                table.Cell().Element(CellStyle).AlignCenter().Text($"{product.Discount}%");
                table.Cell().Element(CellStyle).AlignCenter().Text($"{product.Quantity}");
				table.Cell().Element(CellStyle).AlignRight().Text($"{product.TotalPrice.ToString("N2")} {product.CurrencySymbol}");

				static IContainer CellStyle(IContainer container) => container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
			}
		});
	}

	void ComposeComments(IContainer container)
	{
		container.ShowEntire().Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
		{
			column.Spacing(5);
			column.Item().Text("Note").FontSize(14).SemiBold();
			column.Item().Text(Model.Note);
		});
	}
}
