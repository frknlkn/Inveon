
$(".txtb input").on("focus", function () {
    $(this).addClass("focus");
});

$(".txtb input").on("blur", function () {
    if ($(this).val() == "")
        $(this).removeClass("focus");
});

function checkScroll() {
  var startY = $(".fixed-top").height() * 0.1; //The point where the navbar changes in px

  if ($(window).scrollTop() > startY) {
    $(".fixed-top").addClass("scrolled");
  } else {
    $(".fixed-top").removeClass("scrolled");
  }
}

if ($(".fixed-top").length > 0) {
  $(window).on("scroll load resize", function() {
    checkScroll();
  });
}


$(document).ready(function () {
    $("#link1").click(function (e) {
        e.preventDefault();
        $("body, html").animate(
            {
                scrollTop: 0
            },
            600
        );
    });

    $("#target2").click(function (e) {
        e.preventDefault();
        $("body, html").animate(
            {
                scrollTop: $("#target2").offset().top
            },
            600
        );
    });
});


// the selector will match all input controls of type :checkbox
// and attach a click event handler
$("input:checkbox").on('click', function () {
    // in the handler, 'this' refers to the box clicked on
    var $box = $(this);
    if ($box.is(":checked")) {
        // the name of the box is retrieved using the .attr() method
        // as it is assumed and expected to be immutable
        var group = "input:checkbox[name='" + $box.attr("name") + "']";
        // the checked state of the group/box on the other hand will change
        // and the current value is retrieved using .prop() method
        $(group).prop("checked", false);
        $box.prop("checked", true);
    } else {
        $box.prop("checked", false);
    }
});


