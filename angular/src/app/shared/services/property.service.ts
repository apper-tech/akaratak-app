import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import * as Api from './service.base';
import * as moment from 'moment';
import { AppService } from 'src/app/app.service';
import { DataWithPaging } from 'src/app/app.models';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  public apiUrl = 'api/';


  constructor(public http: HttpClient,
    public propertyService: Api.PropertyServiceProxy,
    public currencyService: Api.CurrencyServiceProxy,
    public categoryService: Api.CategoryServiceProxy,
    public tagService: Api.TagServiceProxy,
    public countryService: Api.CountryServiceProxy,
    public cityService: Api.CityServiceProxy
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
    ];
  }
  public getDirections() {
    return [
      { id: 1, name: 'West', selected: false },
      { id: 2, name: 'East', selected: false },
      { id: 3, name: 'North', selected: false },
      { id: 4, name: 'South', selected: false },
    ];
  }
  public getPropertyStatuses() {
    return [
      { id: 1, name: 'For Sale' },
      { id: 2, name: 'For Rent' },
      { id: 3, name: 'For Invest' },
      { id: 4, name: 'Swap?' }
    ];
  }
  public getProperty(id): Observable<Api.PropertyDto> { return this.propertyService.getById(id); }

  public getPropertiesForUser(): Promise<Api.PropertyDto[]> {
    return new Promise((resolve, reject) => {
      this.propertyService.getByUser().subscribe(data => {
        resolve(data);
      }, error => reject(error));
    });
  }
  public getProperties(params: any, sort?, page?, perPage?): Promise<DataWithPaging> {
    return new Promise((resolve, reject) => {
      this.propertyService.filter(
        params ? this.ToFilterInputDto(params, perPage, page) : {} as Api.FilterPropertyInput
      ).subscribe(data => {
        if (data) {
          resolve(this.paginator(data, sort, page, perPage));
        } else {
          reject();
        }
      });
    });
  }

  public paginator(items: Api.PropertyDto[], sort, page?, perPage?): DataWithPaging {

    // tslint:disable-next-line: one-variable-per-declaration
    page = page || 1;
    perPage = perPage || 4;
    const offset = (page - 1) * perPage;
    const paginatedItems = items.slice(offset).slice(0, perPage);
    const totalPages = Math.ceil(items.length / perPage);
    return {
      data: this.sortFilterProperty(sort, paginatedItems),
      pagination: {
        page,
        perPage,
        prePage: page - 1 ? page - 1 : null,
        nextPage: (totalPages > page) ? page + 1 : null,
        total: items.length,
        totalPages,
      }
    };
  }
  public FromStatusDto(status): Api.OfferPagedResultInput {
    const result = new Api.OfferPagedResultInput();

    status.forEach(stat => {
      switch (stat.id) {
        case 1:
          result.sale = true;
          break;
        case 2:
          result.rent = true;
          break;
        case 3:
          result.invest = true;
          break;
        case 4:
          result.swap = true;
          break;
      }
    });
    return result;
  }
  public FromFeatureDto(features, search: boolean): Api.FeaturesSearchParameters | any[] {
    const result = new Api.FeaturesSearchParameters();
    const list = this.getFeatures().filter((feat) => {
      if (features.cladding && feat.id === 1) { result.cladding = true; return feat; }
      if (features.empty && feat.id === 2) { result.empty = true; return feat; }
      if (features.heating && feat.id === 3) { result.heating = true; return feat; }
      if (features.internet && feat.id === 4) { result.internet = true; return feat; }
      if (features.elevator && feat.id === 5) { result.elevator = true; return feat; }
      if (features.parking && feat.id === 6) { result.parking = true; return feat; }
      if (features.gasLine && feat.id === 7) { result.gasLine = true; return feat; }
    });
    if (search) {
      return result;
    } else {
      return list;
    }
  }
  private sortFilterProperty(sort, data: Api.PropertyDto[]) {
    if (sort) {
      switch (sort) {
        case 'Newest':
          data = data.sort((a, b) => new Date(b.listingDate.toString()).getTime() - new Date(a.listingDate.toString()).getTime());
          break;
        case 'Oldest':
          data = data.sort((a, b) => new Date(a.listingDate.toString()).getTime() - new Date(b.listingDate.toString()).getTime());
          break;
        case 'Popular':
          data = data.sort((a, b) => {
            if (a.views > b.views) {
              return 1;
            }
            if (a.views < b.views) {
              return -1;
            }
            return 0;
          });
          break;
        case 'Price (Low to High)':
          data = data.sort((a, b) => {
            if ((a.offer.sale || a.offer.rent || a.offer.invest) > (b.offer.sale || b.offer.rent || b.offer.invest)) {
              return 1;
            }
            if ((a.offer.sale || a.offer.rent || a.offer.invest) < (b.offer.sale || b.offer.rent || b.offer.invest)) {
              return -1;
            }
            return 0;
          });
          break;
        case 'Price (High to Low)':
          data = data.sort((a, b) => {
            if ((a.offer.sale || a.offer.rent || a.offer.invest) < (b.offer.sale || b.offer.rent || b.offer.invest)) {
              return 1;
            }
            if ((a.offer.sale || a.offer.rent || a.offer.invest) > (b.offer.sale || b.offer.rent || b.offer.invest)) {
              return -1;
            }
            return 0;
          });
          break;
        default:
          break;
      }
    }
    return data;
  }
  private ToOfferDto(basic, update: boolean) {
    let offerResult = null;
    if (!update) {
      offerResult = new Api.CreateOfferInput(
        {
          sale: 0,
          rent: 0,
          invest: 0,
          swap: false,
          currency: 0
        }
      );
    } else {
      offerResult = new Api.UpdateOfferInput(
        {
          sale: 0,
          rent: 0,
          invest: 0,
          swap: false,
          currency: 0
        }
      );
    }
    if (!update) {
      basic.propertyStatus.forEach(stat => {
        switch (stat.id) {
          case 1: offerResult.sale = basic.salePrice; break;
          case 2: offerResult.rent = basic.rentPrice; break;
          case 3: offerResult.invest = basic.investPrice; break;
          case 4: offerResult.swap = true; break;
        }
      });
    } else {
      offerResult.sale = basic.salePrice;
      offerResult.rent = basic.rentPrice;
      offerResult.invest = basic.investPrice;
      offerResult.swap = basic.swap;
    }
    offerResult.currency = basic.propertyCurrency;
    return offerResult;
  }
  private ToFeaturesDto(basic, additional, update: boolean) {
    const features = additional.features;
    let featureResult = null;
    if (!update) {
      featureResult = new Api.CreateFeaturesInput({
        title: '',
        description: '',
        tags: [
        ],
        direction: {} as Api.CreateDirectionDto,
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
    } else {
      featureResult = new Api.UpdateFeaturesInput({
        title: '',
        description: '',
        tags: [
        ],
        direction: {} as Api.UpdateDirectionDto,
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
    }
    features.forEach(feat => {
      const selected = feat.selected;
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
        if (key == fkey) {
          featureResult[key] = additional[key];
        }
      });
    });

    if (!update) {
      featureResult.direction = new Api.CreateDirectionDto();
    } else {
      featureResult.direction = new Api.UpdateDirectionDto();
    }
    additional.directions.forEach(item => {
      if (item.selected) {
        switch (item.name.toLowerCase()) {
          case 'east': featureResult.direction.east = true; break;
          case 'west': featureResult.direction.west = true; break;
          case 'north': featureResult.direction.north = true; break;
          case 'south': featureResult.direction.south = true; break;
        }
      }
    });
    featureResult.propertyAge = additional.yearBuilt;

    featureResult.tags = basic.propertyTags;

    featureResult.title = basic.title;

    featureResult.description = basic.desc;

    return featureResult;
  }
  private ToFilterInputDto(params, perPage, page): Api.FilterPropertyInput {
    console.log(params);
    const filter = {
      propertySearchParameters:
      {
        areaRange: this.validateRange(params.area),
        bathroomsRange: this.validateRange(params.bathrooms),
        bedroomsRange: this.validateRange(params.bedrooms),
        priceRange: this.validateRange(params.price),
        propertyAgeRange: this.validateRange(params.propertyAge),
        features: params.features ? this.FromFeatureDto(params.features, true) : undefined,
        offers: params.propertyStatus ? this.FromStatusDto(params.propertyStatus) : undefined,
        propertyType: params.propertyType ? params.propertyType.id : undefined,
        city: params.city ? params.city.id : 0,
        zipCode: params.zipCode ? params.zipCode : undefined,
      },
      itemsPerPage: perPage,
      pageNumber: page
    } as Api.FilterPropertyInput;
    console.log(filter);
    return filter;
  }
  private validateRange(range) {
    if (range) {
      const from: number = range.from ? range.from : 0;
      let to: number = range.to ? range.to : 0;
      if (to <= from) {
        to = from + 1;
      }
      return {
        minimum: from,
        maximum: to
      };
    }
    return {
      minimum: 0,
      maximum: 0
    };
  }
  private ToAddressDto(address, update: boolean): Api.CreateAddressInput | Api.UpdateAddressInput {
    if (!update) {
      return new Api.CreateAddressInput({
        city: address.city,
        location: address.location,
        zipCode: address.zipCode,
        street: address.street,
        latitude: address.lat,
        longitude: address.lng
      });
    } else {
      return new Api.UpdateAddressInput({
        city: address.city,
        location: address.location,
        zipCode: address.zipCode,
        street: address.street,
        latitude: address.lat,
        longitude: address.lng
      });
    }
  }
  private ToPropertyDto(property, update: boolean): Api.CreatePropertyInput | Api.UpdatePropertyInput {
    const basicParam = property.basic;
    const addressParam = property.address;
    const additionalParam = property.additional;
    if (!update) {
      return new Api.CreatePropertyInput(
        {
          address: this.ToAddressDto(addressParam, update),
          offer: this.ToOfferDto(basicParam, update),
          features: this.ToFeaturesDto(basicParam, additionalParam, update),
          propertyType: basicParam.propertyType,
          expireDate: moment().add(3, 'M')
        }
      );
    } else {
      return new Api.UpdatePropertyInput(
        {
          id: property.id,
          address: this.ToAddressDto(addressParam, update),
          offer: this.ToOfferDto(basicParam, update),
          features: this.ToFeaturesDto(basicParam, additionalParam, update),
          propertyType: basicParam.propertyType,
          expireDate: moment().add(3, 'M')
        }
      );
    }
  }
  public async submitProperty(property): Promise<string> {
    return new Promise<string>(async (resolve, reject) => {
      let result = true;
      this.propertyService.create(this.ToPropertyDto(property, false) as Api.CreatePropertyInput).subscribe(id => {
        if (id) {
          const photos = property.basic.gallery;
          if (photos) {
            photos.forEach(photo => {
              this.propertyService.addPhotoForProperty(id,
                ({ fileName: photo.file.name, data: photo.file } as Api.FileParameter))
                .subscribe(added => {
                  result = added;
                });
            });
          }
        }
        if (result) {
          resolve('success');
        } else {
          reject('Error While Adding');
        }
      });
    });
  }
  public async updateProperty(property): Promise<boolean> {
    console.log(this.ToPropertyDto(property, true) as Api.UpdatePropertyInput);

    return new Promise<boolean>((resolve, reject) => {
      this.propertyService.update(this.ToPropertyDto(property, true) as Api.UpdatePropertyInput).subscribe(result => {
        resolve(result);
      });
    });
  }
  public async deleteProperty(propertyId: number): Promise<boolean> {
    return new Promise<boolean>((resolve, reject) => {
      this.propertyService.remove(propertyId).subscribe(result => {
        resolve(result);
      }, error => reject(error));
    });
  }
}
