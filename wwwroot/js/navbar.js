var ham = document.querySelector(".ham");
var body= document.querySelector("body");
var l=0;
     var hamburger = document.querySelector(".hamburger-icon");
     var navbar = document.querySelector(".respansive-navbar");
     navbardiv=document.createElement("div");
     navbardiv.setAttribute("class", "navbardiv");
     

     hamburger.addEventListener('click',function(){
        hambur();
       
         
     })
     navbardiv.addEventListener('click',function(){
        
        hambur();
        })

        function hambur(){
            if(l==0){
                navbar.style.left=0;
                body.appendChild(navbardiv);
                ham.classList.add("zarb");
                 l++
            } else{
                navbar.style.left="-300px";
                body.removeChild(navbardiv);
                l=0;
                ham.classList.remove("zarb");
            }
        }
        // search section
        var navbarsearch= document.querySelector(".navbar-search-icon");
        var searchform= document.querySelector(".search-form");
       
       
        navbarsearch.addEventListener('click',()=>{
         searchform.classList.toggle('form-width')
        })