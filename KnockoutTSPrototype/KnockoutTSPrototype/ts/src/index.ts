import * as ko from 'knockout';
import { Observable, ObservableArray, PureComputed } from 'knockout';

import Partner from "./models/partner";


//import Partner from "./models/apigen";
//import PersonReadOnly from './components/PersonReadOnly';
//import PersonEditable from './components/PersonEditable';

//import filmsBinding from './bindings/filmsBinding';

//ko.components.register('person-read-only', PersonReadOnly);
//ko.components.register('person-editable', PersonEditable);

//ko.bindingHandlers.films = filmsBinding;

const $ = require('jquery');

class AppViewModel {

  self1: AppViewModel;

  partner = ko.observableArray([]);
  name: Observable<string> = ko.observable('ahoj');
  bLength: Observable<number> = ko.observable(0);
  inputText: Observable<string> = ko.observable('input text');

  constructor() {
    this.self1 = this;
    this.loadData(this.self1);
  }

  init() {
    console.log('AppViewModel.init');
  }

  loadData(a) {
    console.log('lenght: ', this.partner.length);

    $.post(
      "/services/PartnerHandler.ashx",
      {
        action: 'partner',
        name: 'xx'
      },
      function (data) {
        if (data.Success) {

         // this.partner = ko.observableArray(data.Data);

          a.partner(Partner.fromJSArray(data.Data));
          console.log('partner result', a.partner());

          console.log('lenght 2: ', a.partner().length);
          a.bLength(a.partner().lenght);

        } else {
          alert(data.Message);
        }
      });
  }
}

let assetViewModel;

if ($.isEmptyObject(assetViewModel)) {
  assetViewModel = new AppViewModel();
  ko.applyBindings(assetViewModel, document.getElementById('testManager'));
  assetViewModel.init();
}

