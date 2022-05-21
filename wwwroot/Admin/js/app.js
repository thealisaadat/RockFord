// navbar
const formbtn = document.querySelector(".form-btn");
const navbarform = document.querySelector(".navbar-form");

formbtn.addEventListener("click", () => {
  navbarform.classList.toggle("search-active");
});

// sidebar

const aside = document.querySelector("#aside");
const asidespan = document.querySelector(".aside-span");
asidespan.addEventListener("click", () => {
  aside.classList.toggle("active-sidebar");
});
// main section
let tagForm = document.querySelector("#tag-form");
let inputTag = document.querySelector("#input-tag");
let inputTaglink = document.querySelector("#input-tag").children;
const tagBtn = document.querySelector("#tag-btn");
//  tagBtn.addEventListener("click", () => {
//    let aLink = document.createElement("a");

//    aLink.textContent = "#" + tagForm.value;
//    if (tagForm.value === "") {
//      alert("لطفا یک کلمه وارد کنید");
//    } else {
//      inputTag.appendChild(aLink);
//    }

//    for (but of inputTaglink) {
//      but.addEventListener("click", function () {
//        this.style.display = "none";
//      });
//    }
//  });
// keyord

tagForm.addEventListener("keydown", handler);

function handler(event) {
  var p = event.keyCode + " ";
  if (event.keyCode == "17") {
    let aLink = document.createElement("a");

    aLink.textContent = "#" + tagForm.value;
    if (tagForm.value === "") {
      alert("لطفا یک کلمه وارد کنید");
    } else {
      inputTag.appendChild(aLink);
      tagForm.value = "";
    }

    for (but of inputTaglink) {
      but.addEventListener("click", function () {
        this.style.display = "none";
      });
    }
  }
}
