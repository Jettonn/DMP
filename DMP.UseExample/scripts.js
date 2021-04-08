const numItemsToGenerate = 20; //how many gallery items you want on the screen
const numImagesAvailable = 132; //how many total images are in the collection you are pulling from
const imageWidth = 480; //your desired image width in pixels
const imageHeight = 480; //desired image height in pixels
const collectionID = 219941; //the collection ID from the original url
const $galleryContainer = document.querySelector(".gallery-container");

function renderGalleryItem(randomNumber) {
  fetch(
    `https://source.unsplash.com/collection/${collectionID}/${imageWidth}x${imageHeight}/?sig=${randomNumber}`
  ).then((response) => {
    let galleryItem = document.createElement("div");
    galleryItem.classList.add("gallery-item");
    galleryItem.innerHTML = `
        <img class="gallery-image" src="${response.url}" alt="gallery image" onclick="onClick(this)"/>
      `;
    $galleryContainer.appendChild(galleryItem);
  });
}

for (let i = 0; i < numItemsToGenerate; i++) {
  let randomImageIndex = Math.floor(Math.random() * numImagesAvailable);
  renderGalleryItem(randomImageIndex);
}

// Get the modal
var modal = document.getElementById("myModal");
var modalImg = document.getElementById("img01");
var captionText = document.getElementById("caption");
var span = document.getElementsByClassName("close")[0];
span.onclick = function () {
  modal.style.display = "none";
};
function onClick(element) {
  modal.style.display = "block";
  modalImg.src = element.src;
  useDMP(element.src);
}
