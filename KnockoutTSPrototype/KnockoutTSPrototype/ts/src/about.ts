import * as ko from 'knockout';
import { Observable, ObservableArray } from 'knockout';


const $ = require('jquery');

class AboutViewModel {

  self1: AboutViewModel;
  aboutPageTitle: Observable<string> = ko.observable('My About page');


  headerData = ko.observable('');
  bodyData = ko.observable('');
  bodyTemplate = ko.observable('aboutModalTemplate');
  footerData: any = ko.observable({ closeLabel: 'Zavřít' });
  modalSize = ko.observable('');
  modalVisible = ko.observable(false);


  constructor() {
    this.self1 = this;
  }

  init() {

  }

  openModal() {
    this.modalSize('modal-lg');
    this.headerData('Náhled souboru');
    this.bodyTemplate('aboutModalTemplate');
    this.bodyData();
   // this.footerData({ action: this.aboutModalOk, primaryLabel: 'Uložit', closeLabel: 'Zavřít' });
    this.modalVisible(true);
  }

  aboutModalOk() {
    alert('OK');
  }



}

let aboutViewModel;

if ($.isEmptyObject(aboutViewModel)) {
  aboutViewModel = new AboutViewModel();
  ko.applyBindings(aboutViewModel, document.getElementById('aboutViewModelManager'));
  aboutViewModel.init();
}
