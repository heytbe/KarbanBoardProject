ClassicEditor
	.create( document.querySelector( '.editor' ), {
		// Editor configuration.
	} )
	.then( editor => {
		window.editor = editor;
	} );

window.addEventListener('DOMContentLoaded', (event) => {
	adjustBoxContentHeight();

	let btnadd = document.querySelector(".btnadd"),
	taskviewcard = document.querySelector(".taskviewcard"),
	plus = document.querySelectorAll(".boxarea .box .tasklisttitle .fa-plus"),
	ticketinput = document.querySelector(".ticketcontent .createticket"),
	ticketupdate = document.querySelector(".ticketcontent .ticketupdate"),
	ticketcontentarea = document.querySelector(".ticketcontent .ticketcontentarea");


	if(typeof(btnadd) != "undefined" && btnadd != null){
		btnadd.addEventListener("click",function(){
			taskviewcard.style.display = "block";
		});
	}

	if(typeof(plus) != "undefined" && plus != null){
		for(let i = 0; i < plus.length; i++){
			plus[i].addEventListener("click",function(){
				taskviewcard.style.display = "block";
			});
		}
	}

	if(typeof(ticketinput) != "undefined" && ticketinput != null){
		ticketinput.addEventListener("keypress",function(e){
			if (e.key === "Enter") {
				e.preventDefault();
				let html = ` <span>${ticketinput.value}</span>
				<input type="hidden" name="create.ListTicketCreateDtos" value="${ticketinput.value}">
				`;

				ticketcontentarea.insertAdjacentHTML("afterbegin", html);
				ticketinput.value = "";
			}
		});
	}


	if (typeof (ticketupdate) != "undefined" && ticketupdate != null) {
		ticketupdate.addEventListener("keypress", function (e) {
			if (e.key === "Enter") {
				e.preventDefault();
				let html = ` <span>${ticketupdate.value}</span>
				<input type="hidden" name="update.ListTicket" value="${ticketupdate.value}">
				`;

				ticketcontentarea.insertAdjacentHTML("afterbegin", html);
				ticketupdate.value = "";
			}
		});
	}


	let multipleimage = document.querySelector("#add");
	let appendarea = document.querySelector(".add");
	let imagearray = [];
	if (typeof (multipleimage) != 'undefined' && multipleimage != null) {
		multipleimage.addEventListener("change", function () {
			appendarea.innerHTML = "";
			for (let i = 0; i < this.files.length; i++) {
				imagearray.push(this.files[i]);
			}

			multipleimagefunction(imagearray, appendarea);
		});
	}

	document.addEventListener("click", function (e) {
		if (e.target.classList[1] === "imagedelete") {
			let index = e.target.parentElement.parentElement.getAttribute("data-index");
			imagearray.splice(index, "1");
			appendarea.innerHTML = "";
			multipleimagefunction(imagearray, appendarea);
		}
	});

	function multipleimagefunction(dizi, area) {
		for (let i = 0; i < dizi.length; i++) {
			let reader = new FileReader(dizi[i]);

			reader.onload = function () {
				reader.name = dizi[i].name;

				let html = `<div class="flex-start-start-row file" data-index="${i}">
				<div class="column30 image">
					<img src="${reader.result}" alt="">
				</div>
				<div class="column70 imagedescription">
					<span class="delete  imagedelete">Sil</span>
				</div>
			</div>`;
				area.insertAdjacentHTML("beforeend", html);
			}
			reader.readAsDataURL(dizi[i]);
		}
	}

	$(".createbtn").on("click", function () {
		let id = $(this).attr("data-id");
		$("#cardCreate").attr("data-id",id);
	});

	$("body").on("submit", "#cardCreate", function (event) {
		event.preventDefault();
		let id = $(this).attr("data-id");
		var formdata = new FormData(this);
		if (imagearray.length !== 0) {
			for (var i = 0; i < imagearray.length; i++) {
				formdata.append("create.ListAddition", imagearray[i]);
			}
		}
		$.ajax({
			url: `/TaskList/Create?itemid=${id}`,
			type: "POST",
			data: formdata,
			contentType: false,
			cache: false,
			processData: false,
			success: function (data) {
				alert("Card Eklendi");
			}
		});
	});

	$("body").on("submit", "#updateCreate", function (event) {
		event.preventDefault();
		let id = $(this).attr("data-id");
		var formdata = new FormData(this);
		if (imagearray.length !== 0) {
			for (var i = 0; i < imagearray.length; i++) {
				formdata.append("update.ListAddition", imagearray[i]);
			}
		}
		$.ajax({
			url: `/TaskList/Update?itemid=${id}`,
			type: "POST",
			data: formdata,
			contentType: false,
			cache: false,
			processData: false,
			success: function (data) {
				alert("Card Güncellendi");
			}
		});
	});
});

$(document).ready(function() {
	$(".card").hover(
		function() {
			$(this).find(".setting").css("display", "block");
		},
		function() {
			$(this).find(".setting").css("display", "none");
		}
	);
});

window.addEventListener('resize', (event) => {
	adjustBoxContentHeight();
});

function adjustBoxContentHeight() {
	let boxContents = document.querySelectorAll('.boxcontent'),
	mainarea = document.querySelector(".mainarea"),
	taskviewcardcontent = document.querySelector(".taskviewcard .content")
	modalcontent = document.querySelector(".modal .content");


	mainarea.style.height = (window.innerHeight) + "px";
	taskviewcardcontent.style.height = (window.innerHeight - 40) + "px";
	boxContents.forEach(function(boxContent) {
		if(boxContent.clientHeight > mainarea.clientHeight){
			boxContent.style.height = (mainarea.clientHeight - 120) + "px";
		}
	});	
}

document.addEventListener("click",function(e){
	if (e.target.classList == "taskviewcard" || e.target.classList == "modal") {
		if (e.target.parentNode.classList != "mainarea") {
			e.target.style.display = "none";
		}
	}
});

let openmenu = document.querySelector("#openmenu"),
	menuarea = document.querySelector(".menuarea"),
	menuareahome = document.querySelector(".menuarea .home"),
	menuitem = document.querySelector(".menuitem");

let i = 0;
openmenu.addEventListener("click", function () {
	if (i === 0) {
		menuarea.style.width = "80%";
		menuarea.style.zIndex = "99999";
		menuarea.style.backgroundColor = "rgba(255,255,255,.9)";
		menuareahome.style.setProperty("display", "block", "important");
		menuitem.style.setProperty("display", "block", "important");
		this.className = "";
		this.className = "fa-solid fa-arrow-left";
		i = 1;
	} else {
		menuarea.style.width = "80px";
		menuarea.style.zIndex = "0";
		menuarea.style.backgroundColor = "rgba(255,255,255,.9)";
		menuareahome.style.setProperty("display", "none", "important");
		menuitem.style.setProperty("display", "none", "important");
		this.className = "";
		this.className = "fa-solid fa-right-long";
		i = 0;
	}
});
