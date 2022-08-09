// ================== CountDown function ================
$('.countdown_timer').each(function(){
    $('[data-countdown]').each(function() {
      var $this = $(this), finalDate = $(this).data('countdown');
      $this.countdown(finalDate, function(event) {
        var $this = $(this).html(event.strftime(''
        + '<span class="text-danger" style="font-weight:600;">%M:%S</span>'));
      });
    });
  });







let images = document.querySelectorAll(".answer-image img");
let divImages = document.querySelectorAll(".answer-image")
let contetns = document.querySelectorAll(".exam-content")
images.forEach((image,index) => {
  if(image.alt=="empty"){
    contetns.forEach((content,i) => {
      if(index==i){
        content.style.width= 100 +"%";
      }
    })
    divImages.forEach((divImage,j) => {
      if(index==j){
        divImage.style.display="none";
      }
    })
  }
});
