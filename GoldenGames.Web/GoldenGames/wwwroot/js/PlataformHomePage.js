var data = [
    { text: 'XBox', id: '11' },
    { text: 'PlayStation', id: '12' },
    { text: 'Wii', id: '13' },
    { text: 'Nintendo', id: '14' },
    { text: 'Nintendo Switch', id: '15' },
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
listviewInstance.appendTo("#platform-element");

var data = [
    { text: 'XBox', id: '11' },
    { text: 'PlayStation', id: '12' },
    { text: 'Wii', id: '13' },
    { text: 'Nintendo', id: '14' },
    { text: 'Nintendo Switch', id: '15' },
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
listviewInstance.appendTo("#platform-element");