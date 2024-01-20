function Delete(element,url) {
	$.ajax({
		url: url,
		type: "GET",
		success: function (data) {
			console.log(data);
			if (data === "Silindi") {
				$(element).parent().parent().parent().remove();
			} else if (data === "Etiket Silindi") {
				$(element).remove();
			} else if (data === "Dosya Silindi") {
				$(element).parent().parent().remove();
			}
		}
	});
}