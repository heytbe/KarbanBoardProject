function GetBoardList(id) {
    $.ajax({
        url: `/TaskList/List?itemid=${id}`,
        type: "GET",
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert("Liste Bulunamadı");
            } else {
                let html = `
                    <div class="content">
                        <div class="flex-between-start area">
                            <div class="column70">
                                <section class="flex-start-start-column title">
                                    <div class="flex-start-start-row">
                                        <i class="fa-solid fa-plus"></i>
                                        <span class="cardtitle">Başlık</span>
                                    </div>
                                    ${response.data.cardName}
                                </section>
                                <section class="fullscreen ticketadd">
                                    <div class="flex-start-start-row title">
                                        <i class="fa-solid fa-ticket"></i>
                                        <span class="tickettitle">Etiketler</span>
                                    </div>
                                    <div class="flex-start-start-row wrap ticketcontent">
                                        <div class="flex-start-start-row ticketcontentarea">`;
                                    $.each(response.data.listTickets, function (index, ticket) {
                                        html += `<span>${ticket.name}</span>`;
                                    });

                                    html += `</div>
                                    </div>
                                </section>
                                <section class="fullscreen description">
                                    <div class="flex-start-start-row title">
                                        <i class="fa-solid fa-message"></i>
                                        <span class="cardtitle">Açıklama</span>
                                    </div>
                                    ${response.data.description}
                                </section>
                                <section class="fullscreen addition">
                                    <div class="flex-start-start-row title">
                                        <i class="fa-solid fa-paperclip"></i>
                                        <span class="cardtitle">Eklentiler</span>
                                    </div>
                                    <div class="flex-start-start-column wrap add">`;


                $.each(response.data.listAdditions, function (index, addition) {
                    html += `<div class="flex-start-start-row file" data-index="${index}">
                                    <div class="column30 image">
                                        <img src="https://localhost:7206/${addition.path}" alt="">
                                    </div>
                                    <div class="column70 imagedescription">
                                        ${addition.name}
                                    </div>
                                </div>`;
                });

                html += `</div>
                                </section>
                            </div>
                            <div class="column30">
                                <div class="input">
                                    <span class="title"><i class="fa-solid fa-calendar-days"></i>Tarih</span>
                                    <div class="fullscreen datebox">
                                        <span class="flex-start-start-row start">Başlangıç</span>
                                        ${response.data.startDate}
                                        <span class="flex-start-start-row end">Bitiş</span>
                                        ${response.data.finisDate}
                                    </div>
                                </div>
                                <div class="input">
                                    <span class="title"><i class="fa-solid fa-fill-drip"></i>Renk</span>
                                    <div class="fullscreen cardcolorarea" style="background-color:${response.data.cardColor}"></div>
                                </div>
                            </div>
                        </div>
                    </div>`;
                $(".modal").html(html);
                $(".modal").css("display", "block");
            }
        },
        error: function (error) {
            console.error("Ajax request failed: ", error);
        }
    });
}

