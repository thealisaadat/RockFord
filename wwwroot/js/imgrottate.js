// var img=document.querySelector('.img');
// var main=document.querySelector('.main');
// window.onmousemove = function(e){
//     img.classList.add('img-animation');
// }

// 
// window.onmousemove=function(event){
//     var x=event.clientX;
//     var y=event.clientY;
    
// }
const container =document.querySelector('.main');
var body =document.body;
  body.addEventListener("mousemove", (e) => {
    const eye = document.querySelector(".eye");
    var main =document.querySelector('.img');
      let mouseX = eye.getBoundingClientRect().right;
      if (eye.classList.contains("eye-left")) {
        mouseX = eye.getBoundingClientRect().left;
      }
      let mouseY = eye.getBoundingClientRect().top;
      let radianDegrees = Math.atan2(e.pageX - mouseX, e.pageY - mouseY);
      let rotationDegrees = radianDegrees * (180 / Math.PI) * -1 + 180;
      main.style.webkitTransform = 'rotate('+rotationDegrees+'deg)'; 
      main.style.mozTransform    = 'rotate('+rotationDegrees+'deg)'; 
      main.style.msTransform     = 'rotate('+rotationDegrees+'deg)'; 
      main.style.oTransform      = 'rotate('+rotationDegrees+'deg)'; 
      main.style.transform       = 'rotate('+rotationDegrees+'deg)'; 
   
    
  });
   

