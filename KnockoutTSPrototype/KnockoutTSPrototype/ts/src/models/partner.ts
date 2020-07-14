export class P {

}

export default P;

//import * as ko from 'knockout';
//import { Observable, ObservableArray, PureComputed } from 'knockout';


//export class Partner {
//  name?: string;
//  city?: string;

//  init(_data?: any) {
//    if (_data) {
//      this.name = _data["Name"];
//      this.city = _data["City"];
//    }
//  }


//  static fromJS(data: any): Partner {
//    data = typeof data === 'object' ? data : {};
//    let result = new Partner();
//    result.init(data);
//    return result;
//  }

//  static fromJSArray(data: any): Array<Partner> {
//    data = typeof data === 'object' ? data : {};

//    let result = new Array<Partner>();
//    data.forEach(x => {
//      let p = new Partner();
//      p.init(x);
//      result.push(p);
//    });

//    return result;
//  }


//}


//export default Partner;