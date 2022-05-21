var contain = document.querySelector(".slider-container").children;
var slider = contain.length;
var left = document.querySelector(".slid-left");
var right = document.querySelector(".slid-right");
 var Index = 0
 var durition=6000;
 var progress = document.querySelector(".progress");
 var textoverlay= document.querySelectorAll(".text-overlay");
 


 left.addEventListener('click',function(){
    slid('left');
 }) 
 right.addEventListener('click',function(){
    slid('right');
    
 }) 

     function slid(dirction){
        autoprogress();
          if(dirction=='right'){
              if(Index==slider-1)
              {
                Index=0
            }
              else{
                Index++
            }
          
          }
          if(dirction=='left'){
            if(Index==0)
            {
                Index=slider-1
          }
            else{
                Index--
          }
        }
         
          clearInterval(timer);
          timer =setInterval(autoslid,durition)
       
        for(i=0;i<slider;i++){
            contain[i].classList.remove("active");
            textoverlay[i].classList.remove("class");

        }
        contain[Index].classList.add("active");
        textoverlay[Index].classList.add("class");
          
     }
     function autoprogress(){
        progress.innerHTML="";
         div=document.createElement("div");
         div.setAttribute("class", "arash");
        div.style.animation="protime "+ durition/1000 + "s linear";
        progress.appendChild(div);
     }
     



     function autoslid(){
        slid('right');
     }
     let timer =setInterval(autoslid,durition)
    
     
     autoprogress();
     

     