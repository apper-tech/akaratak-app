import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import * as Api from './service.base';
import * as moment from 'moment';
import { CreateOfferInput, CreateFeaturesInput } from './service.base';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  public apiUrl = "api/";


  constructor(public http: HttpClient,
    public propertyService: Api.PropertyServiceProxy,
    public currencyService: Api.CurrencyServiceProxy,
    public categoryService: Api.CategoryServiceProxy,
    public tagService: Api.TagServiceProxy,
    public countryService: Api.CountryServiceProxy,
    public cityService: Api.CityServiceProxy,
    public photoService: Api.PhotoServiceProxy
  ) { }

  public getCurrencies(): Observable<Api.CurrencyDto[]> { return this.currencyService.getAll(); }

  public getPropertyTypes(): Observable<Api.CategoryDto[]> { return this.categoryService.getAll(); }

  public getPropertyTags(): Observable<Api.TagDto[]> { return this.tagService.getAll(); }

  public GetCountries(): Observable<Api.CountryDto[]> { return this.countryService.getAll(); }

  public getPropertyCities(id): Observable<Api.CityDto[]> { return this.cityService.getByCountry(id); }

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


  private ToOfferDto(basic) {
    let offerResult = new CreateOfferInput(
      {
        sale: 0,
        rent: 0,
        invest: 0,
        swap: false,
        currency: 0
      }
    );
    basic['propertyStatus'].forEach(stat => {
      switch (stat.id) {
        case 1: offerResult.sale = basic.salePrice; break;
        case 2: offerResult.rent = basic.rentPrice; break;
        case 3: offerResult.invest = basic.investPrice; break;
        case 4: offerResult.swap = true; break;
      }
    });
    offerResult.currency = basic['propertyCurrency'];
    return offerResult;
  }
  private ToFeaturesDto(basic, additional) {
    let features = additional['features'];
    var featureResult = new CreateFeaturesInput({
      title: "",
      description: "",
      tags: [
      ],
      direction: [
      ],
      cladding: false,
      empty: false,
      heating: false,
      gasLine: false,
      internet: false,
      elevator: false,
      parking: false,
      area: 0,
      owners: 0,
      rooms: 0,
      bathrooms: 0,
      bedrooms: 0,
      balconies: 0,
      propertyAge: 0
    });

    features.forEach(feat => {
      var selected = feat.selected;
      switch (feat.id) {
        case 1: featureResult.cladding = selected; break;
        case 2: featureResult.empty = selected; break;
        case 3: featureResult.heating = selected; break;
        case 4: featureResult.internet = selected; break;
        case 5: featureResult.elevator = selected; break;
        case 6: featureResult.parking = selected; break;
        case 7: featureResult.gasLine = selected; break;
      }
    });
    Object.keys(additional).forEach(key => {
      Object.keys(featureResult).forEach(fkey => {
        if (key == fkey)
          featureResult[key] = additional[key]
      })
    });

    featureResult.direction = (function () {
      var directions = [];
      additional['directions'].forEach(item => {
        if (item.selected)
          directions.push(item.id);
      });
      return directions;
    })();
    featureResult.propertyAge = additional['yearBuilt'];
    featureResult.tags = basic['propertyTags'];
    featureResult.title = basic['title'];
    featureResult.description = basic['desc'];
    return featureResult;
  }
  private ToAddressDto(address) {
    var addressResult = new Api.CreateAddressInput({
      city: address['city'],
      location: address['location'],
      zipCode: address['zipCode'],
      street: address['street'],
      latitude: address['lat'],
      longitude: address['lng']
    });
    return addressResult;
  }
  private ToPropertyDto(property) {
    let basicParam = property['basic'];
    let addressParam = property['address'];
    let additionalParam = property['additional'];

    return new Api.CreatePropertyInput(
      {
        address: this.ToAddressDto(addressParam),
        offer: this.ToOfferDto(basicParam),
        features: this.ToFeaturesDto(basicParam, additionalParam),
        propertyType: basicParam['propertyType'],
        expireDate: moment().add(3, 'M')
      }
    );
  }
  public async submitProperty(property): Promise<string> {
    return new Promise<string>(async (resolve, reject) => {
      var result = true;
      this.propertyService.create(this.ToPropertyDto(property)).subscribe(id => {
        if (id) {
          var photos = property['basic']['gallery'];
          if (photos)
            photos.forEach(photo => {
              this.photoService.addPhotoForProperty(id,
                ({ fileName: photo.file.name, data: photo.file } as Api.FileParameter))
                .subscribe(added => {
                  result = added;
                });
            });
        }
        if (result)
          resolve('success');
        else
          reject('Error While Adding');
      })
    })
  }
}
