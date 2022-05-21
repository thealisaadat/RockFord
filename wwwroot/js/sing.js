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

//form.addEventListener("submit", (e) => {
//  e.preventDefault();

//  checkInput();
//});
//logForm.addEventListener("submit", (e) => {

//  e.preventDefault();

//  checkLogin();
//});

function checkInput() {
  const usernameValue = username.value.trim();
  const emailValue = email.value.trim();
  const passwordValue = password.value.trim();
  const password2Value = password2.value.trim();

  if (usernameValue === "") {
    setError(
      username,
      "این فیلد نمیتواند خالی باشد نامی برای خود انتخاب کنید."
    );
  } else {
    setSuccess(username);
  }

  if (emailValue === "") {
    setError(email, "مقدار ایمیل نمیتواند خالی باشد.");
  } else if (!isEmail(emailValue)) {
    setError(email, "ایمیل وارد شده صحیح نیست.");
  } else {
    setSuccess(email);
  }

  if (passwordValue === "") {
    setError(password, "مقدار پسوورد خالی است پسووردی وارد کنید.");
  } else {
    setSuccess(password);
  }

  if (password2Value === "") {
    setError(password2, "مقدار پسوورد خالی است پسووردی وارد کنید.");
  } else if (passwordValue !== password2Value) {
    setError(password2, "پسووردها با هم برابر نیستند.");
  } else {
    setSuccess(password2);
  }
}

function setError(input, message) {
  const formControl = input.parentElement;
  const span = formControl.querySelector("span");

  span.innerHTML = message;

  console.log(span);
  formControl.className = "form-control error";
}

function setSuccess(input) {
  const formControll = input.parentElement;
  formControll.className = "form-control success";
}

const pattern =
  /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

function isEmail(email) {
  return pattern.test(email);
}
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

function checkLogin() {
  const logpasswordValue = logPassword.value.trim();
  const logusernameValue = logUsername.value.trim();

  if (logusernameValue === "") {
    setError(
      logUsername,
      "این فیلد نمیتواند خالی باشد نامی برای خود انتخاب کنید."
    );
  } else {
    setSuccess(logUsername);
  }

  if (logpasswordValue === "") {
    setError(logPassword, "مقدار پسوورد خالی است پسووردی وارد کنید.");
  } else {
    setSuccess(logPassword);
  }
}
