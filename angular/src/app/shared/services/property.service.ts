import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpResponse, HttpRequest } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Property, Location, Currency, Category, Tag, Country, City, InsertProperty, Offer } from '../../app.models';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  public apiUrl = "api/";


  constructor(public http: HttpClient) { }

  public getCurrencies(): Observable<Currency[]> {
    return this.http.get<Currency[]>(this.apiUrl + 'Currency');
  }

  public getPropertyTypes(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl + 'Category');
  }

  public getPropertyCities(code): Observable<City[]> {
    return this.http.get<City[]>(this.apiUrl + 'City/' + code);
  }

  public getPropertyTags(): Observable<Tag[]> {
    return this.http.get<Tag[]>(this.apiUrl + 'Tag');
  }

  public GetCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(this.apiUrl + 'Country');
  }
  public getFeatures() {
    return [
      { id: 1, name: 'Cladding', selected: false },
      { id: 2, name: 'Empty', selected: false },
      { id: 3, name: 'Heating System', selected: false },
      { id: 4, name: 'Internet', selected: false },
      { id: 5, name: 'Elevator', selected: false },
      { id: 6, name: 'Parking', selected: false },
      { id: 7, name: 'Gasline', selected: false }
    ]
  }
  public getDirections() {
    return [
      { id: 1, name: 'West', selected: false },
      { id: 2, name: 'East', selected: false },
      { id: 3, name: 'North', selected: false },
      { id: 4, name: 'South', selected: false },
    ]
  }
  public getPropertyStatuses() {
    return [
      { id: 1, name: 'For Sale' },
      { id: 2, name: 'For Rent' },
      { id: 3, name: 'For Invest' },
      { id: 4, name: 'Swap?' }
    ]
  }
  private getOfferForInsert(key, value) {
    let offer = new Offer();
    key.forEach(stat => {
      switch (stat.id) {
        case 1: offer.sale = value.salePrice; break;
        case 2: offer.rent = value.rentPrice; break;
        case 3: offer.invest = value.investPrice; break;
        case 4: offer.swap = true; break;
      }
    });
    offer['currency'] = value['propertyCurrency'];
    return offer;
  }
  private getCastValueForInsert(key, obj, value) {
    switch (key) {
      case 'propertyCurrency': obj['currency'] = value; break;
      case 'propertyTags': obj['tags'] = value; break;
      case 'propertyType': obj['type'] = value; break;
      case 'yearBuilt': obj['propertyAge'] = value; break;
      case 'desc': obj['description'] = value; break;
      case 'directions':
        value.forEach(direct => {
          var selected = direct.selected;
          switch (direct.id) {
            case 1: obj['directionWest'] = selected; break;
            case 2: obj['directionEast'] = selected; break;
            case 3: obj['directionNorth'] = selected; break;
            case 4: obj['directionSouth'] = selected; break;
          }
        });
        break;
      case 'features':
        value.forEach(feat => {
          var selected = feat.selected;
          switch (feat.id) {
            case 1: obj['cladding'] = selected; break;
            case 2: obj['empty'] = selected; break;
            case 3: obj['heating'] = selected; break;
            case 4: obj['internet'] = selected; break;
            case 5: obj['elevator'] = selected; break;
            case 6: obj['parking'] = selected; break;
            case 7: obj['gasLine'] = selected; break;
          }
        });
        break;
    }
    return obj;
  }
  private addPhotosToProperty(id, photos) {

    const formData = new FormData();

    for (let photo of photos)
      formData.append(photo.file.name, photo.file);
    console.log(formData);
    const uploadReq = new HttpRequest('POST', `${this.apiUrl}Photos/${id}`, formData, {
      reportProgress: true,
    });
    console.log(uploadReq);

    this.http.request(uploadReq).subscribe(event => {
      console.log(event);
      return true;
    });
  }
  public submitProperty(property): Observable<string> {
    let basic = property['basic'];
    let address = property['address'];
    let additional = property['additional'];

    let offer = this.getOfferForInsert(basic.propertyStatus, basic);
    console.log(property);

    let obj = new InsertProperty();
    let objKeys = Object.getOwnPropertyNames(obj);
    Object.keys(property).forEach(key => {
      Object.keys(property[key]).forEach(inner => {
        var value = property[key][inner];
        obj = this.getCastValueForInsert(inner, obj, value);
        if (objKeys.includes(inner))
          obj[inner] = value;
      });
    });

    obj['offer'] = offer;
    obj['latitude'] = address.lat;
    obj['longitude'] = address.lng;
    console.log(obj);
    this.addPhotosToProperty(1, basic.gallery);
    this.http.post(`${this.apiUrl}Property/AddProperty`, obj).subscribe(response => {
      console.log(response);

      return of('success');
    })
    return of('failed');
  }
}
