var data = [
    { text: 'Ação', id: '1' },
    { text: 'Aventura', id: '2' },
    { text: 'Desporto', id: '3' },
    { text: 'Fantasia', id: '4' },
    { text: 'MMORPG', id: '5' },
    { text: 'MOBA', id: '6' },
    { text: 'Terror', id: '7' },
    { text: 'Indie', id: '8' },
    { text: 'Singleplayer', id: '9' },
    { text: 'Multiplayer', id: '10' },
];
//Initialize ListView component
var listviewInstance = new ej.lists.ListView({
    //set the data to datasource property
    dataSource: data,

    //Enable checkbox
    showCheckBox: true,

    //Set Checkbox position
    checkBoxPosition: 'Left'

});
//Render initialized ListView
listviewInstance.appendTo("#element");


var carouselObj = new ej.navigations.Carousel({
    items: [
        { template: '<figure class="img-container"><img src="/Images/God-of-War-Ragnarok-imagem-oficial.webp" alt="cardinal" style="height:100%;width:100%;" /><figcaption class="img-caption"></figcaption></figure>' },
        { template: '<figure class="img-container"><img src="/Images/New_World.jpg" alt="kingfisher" style="height:100%;width:100%;" /><figcaption class="img-caption"></figcaption></figure>' },
        { template: '<figure class="img-container"><img src="/Images/Uncharted4_Thiefs_End.jpg" alt="keel-billed-toucan" style="height:100%;width:100%;" /><figcaption class="img-caption"></figcaption></figure>' },
        { template: '<figure class="img-container"><img src="/Images/Apex_Legends.jpg" alt="yellow-warbler" style="height:100%;width:100%;" /><figcaption class="img-caption"></figcaption></figure>' },
        { template: '<figure class="img-container"><img src="/Images/The_Calisto_Protocol.jpg" alt="bee-eater" style="height:100%;width:100%;" /><figcaption class="img-caption"></figcaption></figure>' }
      ],
    autoPlay: true
});
carouselObj.appendTo('#carousel');  