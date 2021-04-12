var userDate = new Date();
var userDateToUTC = userDate.toUTCString();

var dmp = {
  eventType: null,
  contentId: null,
  contentName: null,
  contentType: null,
  contentDescription: null,
  contentImage: null,
  contentValue: null,
  contentAuthor: null,
  userId: null,
  userDmpId: null,
  organizationId: null,
  clientDateTime: userDateToUTC,
  clientDateTimeUTC: userDateToUTC,
  url: document.URL,
  referrer: document.referrer,
  ipAddress: sessionStorage.getItem("ip"),
  deviceLanguage: window.navigator.language,
  deviceScreenResolution: screen.width + "x" + screen.height,
  userAgentInfo: navigator.userAgent,

  init: function (organizationId, userId) {
    this.organizationId = organizationId;
    this.userId = userId;
    this.userDmpId = this.getUserIdFromLocalStorage();
  },
  logevent: function (eventType, contentInformation) {
    this.eventType = eventType;
    this.contentId = contentInformation.id;
    this.contentName = contentInformation.name;
    this.contentType = contentInformation.type;
    this.contentDescription = contentInformation.description;
    this.contentImage = contentInformation.image;
    this.contentValue = contentInformation.value;
    this.contentAuthor = contentInformation.author;
    var eventDto = {
      EventType: this.eventType,
      ContentId: this.contentId,
      ContentName: this.contentName,
      ContentType: this.contentType,
      ContentDescription: this.contentDescription,
      ContentImage: this.contentImage,
      ContentValue: this.contentValue,
      ContentAuthor: this.contentAuthor,
      UserId: this.userId,
      UserDmpId: this.userDmpId,
      OrganizationId: this.organizationId,
      Url: this.url,
      Referrer: this.referrer,
      UserAgent: this.userAgentInfo,
      IpAddress: this.ipAddress,
      DeviceLanguage: this.deviceLanguage,
      DeviceScreenResolution: this.deviceScreenResolution,
    };
    // console.log(eventDto);
    $.ajax({
      url: "https://localhost:44355/api/Event",
      type: "POST",
      contentType: "application/json",
      data: JSON.stringify(eventDto),
      success: function (data, status) {
        console.log("the request is " + status + " the event is " + data);
      },
      error: function (html, status, error) {
        console.log("the request is " + error);
      },
    });
  },
  // Console: function () {
  //   console.log(
  //     this.organizationId,
  //     this.userId,
  //     this.eventType,
  //     this.contentImage
  //   );
  // },
  getUserIdFromLocalStorage: function () {
    var userDmpId = window.localStorage.getItem("userDmpId");
    if (userDmpId != null) {
      return userDmpId;
    } else {
      var guidGenerated = uuidv4();
      window.localStorage.setItem("userDmpId", guidGenerated);
      return window.localStorage.getItem("userDmpId");
    }
  },
};

function useDMP(imageUrl) {
  dmp.init("2E1E7955-1286-473F-9516-08D8EA126CC6", "jetonkorenica@gmail.com");
  var contentInformation = {
    id: "imageId",
    name: "Images from Unsplash",
    type: "image",
    description: "Description of the image",
    image: imageUrl,
    value: null,
    author: "JK",
  };
  dmp.logevent("imageClick", contentInformation);
  // dmp.Console();
}

function uuidv4() {
  return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, (c) =>
    (
      c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (c / 4)))
    ).toString(16)
  );
}

// function AddOrganization(organizationName, organizationInformation) {
//   var organizationData = {
//     OrganizationName: organizationName,
//     OrganizationInformation: organizationInformation,
//   };

//   $.ajax({
//     url: "https://localhost:44355/api/Organization",
//     type: "POST",
//     contentType: "application/json",
//     data: JSON.stringify(organizationData),
//     success: function (data, status) {
//       console.log("the request is " + status + " the data is " + data);
//     },
//     error: function (html, status, error) {
//       console.log("the request is " + error);
//     },
//   });
// }

// $.getJSON("https://localhost:44355/api/Organization", function (data) {
//   console.log(data);
// });
