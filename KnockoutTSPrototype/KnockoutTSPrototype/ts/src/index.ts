import * as ko from 'knockout';
import { Observable, ObservableArray } from 'knockout';

import { Partner } from "./models/api";
import { PartnerSearchDto } from "./dtos/partnerSearchDto";
import { DataUtils } from "./utils/dataUtils";

const $ = require('jquery');

class AppViewModel {

  self1: AppViewModel;
  partner: ObservableArray<Partner> = ko.observableArray([]);
  searchName: Observable<string> = ko.observable('');


  constructor() {
    this.self1 = this;
  }

  init() {
    console.log('AppViewModel.init');
    this.loadData(this);
  }

  search() {
    this.loadData(this);
  }

  loadData(avm: AppViewModel) {

    const reqPar: PartnerSearchDto = {
      action: 'partner',
      name: avm.searchName()
    }

    $.post(
      "/services/PartnerHandler.ashx",
      reqPar,
      function (data) {
        if (data.Success) {
          avm.partner(DataUtils.fromJSArrayPartner(data.Data));
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

