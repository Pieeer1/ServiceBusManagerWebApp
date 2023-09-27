export function resizeListener(dotnetHelper) {
  $(window).resize(() => {
    dotnetHelper.invokeMethodAsync('BrowserResized').then(() => {
    }).catch(error => {
      console.log("Error during browser resize: " + error);
    });
  });
}