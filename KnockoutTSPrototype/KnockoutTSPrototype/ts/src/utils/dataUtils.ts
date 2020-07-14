import { Partner } from '../models/api';

export class DataUtils {

  static fromJSArrayPartner(data): Array<Partner> {

    let result = new Array<Partner>();
    data.forEach(x => {
      let o = new Partner();
      o.init(x);
      result.push(o);
    });

    return result;
  }
}

export default DataUtils;