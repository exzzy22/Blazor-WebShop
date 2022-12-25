
// Mobile Nav toggle
document.querySelector('.menu-toggle > a').addEventListener('click', function(e) {
	e.preventDefault();
	document.getElementById('responsive-nav').classList.toggle('active');
  });
  

// Fix cart dropdown from closing
document.querySelector('.cart-dropdown').addEventListener('click', function(e) {
	e.stopPropagation();
  });
  

	/////////////////////////////////////////

function ProductsSlick() {
    // Products Slick
    const productsSlick = document.querySelectorAll('.products-slick');

    productsSlick.forEach(function (slider) {
        const nav = slider.getAttribute('data-nav');
        const options = {
            slidesToShow: 4,
            slidesToScroll: 1,
            autoplay: true,
            infinite: true,
            speed: 300,
            dots: false,
            arrows: true,
            appendArrows: nav ? nav : false,
            responsive: [{
                breakpoint: 991,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                }
            },
            ]
        };

        // Initialize the Slick Slider plugin
        $(slider).slick(options);
    });
}

function ProductsWidgetSlick() {

    // Products Widget Slick
    const productsWidgetSlick = document.querySelectorAll('.products-widget-slick');

    productsWidgetSlick.forEach(function (slider) {
        const nav = slider.getAttribute('data-nav');
        const options = {
            infinite: true,
            autoplay: true,
            speed: 300,
            dots: false,
            arrows: true,
            appendArrows: nav ? nav : false,
        };

        // Initialize the Slick Slider plugin
        $(slider).slick(options);
    });
}



	/////////////////////////////////////////

// Product Main img Slick
const productMainImg = document.getElementById('product-main-img');
const options = {
  infinite: true,
  speed: 300,
  dots: false,
  arrows: true,
  fade: true,
  asNavFor: '#product-imgs',
};
// Initialize the Slick Slider plugin
$(productMainImg).slick(options);

// Product imgs Slick
const productImgs = document.getElementById('product-imgs');
const optionsImgs = {
  slidesToShow: 3,
  slidesToScroll: 1,
  arrows: true,
  centerMode: true,
  focusOnSelect: true,
  centerPadding: 0,
  vertical: true,
  asNavFor: '#product-main-img',
  responsive: [{
      breakpoint: 991,
      settings: {
        vertical: false,
        arrows: false,
        dots: true,
      }
    },
  ]
};
// Initialize the Slick Slider plugin
$(productImgs).slick(optionsImgs);


// Product img zoom
const zoomMainProduct = document.getElementById('product-main-img');
if (zoomMainProduct) {
  const preview = zoomMainProduct.querySelector('.product-preview');
  preview.addEventListener('mouseover', function() {
    this.style.cursor = 'zoom-in';
  });
  preview.addEventListener('click', function() {
    this.style.cursor = 'zoom-out';
    this.style.transform = 'scale(1.5)';
  });
  preview.addEventListener('mouseout', function() {
    this.style.cursor = 'zoom-in';
    this.style.transform = 'scale(1)';
  });
}



