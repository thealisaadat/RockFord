const changesingup = document.querySelector(".change-singup");
const changelogin = document.querySelector(".change-login");
const login = document.querySelector(".login");
const singup = document.querySelector(".singup");
const form = document.getElementById("form");
const logForm = document.getElementById("login-form");
const username = document.getElementById("username");
const logUsername = document.getElementById("login-username");
const email = document.getElementById("email");
const password = document.getElementById("password");
const logPassword = document.getElementById("login-password");
const password2 = document.getElementById("password2");


// singin
changelogin.addEventListener("click", function () {
  singup.classList.add("singrot");
  login.classList.remove("singrot");
  changesingup.classList.remove("active");
  changelogin.classList.add("active");
});
changesingup.addEventListener("click", function () {
  singup.classList.remove("singrot");
  login.classList.add("singrot");
  changesingup.classList.add("active");
  changelogin.classList.remove("active");
});


