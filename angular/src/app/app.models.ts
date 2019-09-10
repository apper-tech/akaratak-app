export class Describer {
    static describe(instance): Array<string> {
        return Object.getOwnPropertyNames(instance);
    }
}
export interface MapAddressDto {
    plus_code: MapPlusCode;
    results: MapResult[];
    status: string;
}

export interface MapPlusCode {
    compound_code: string;
    global_code: string;
}

export interface MapResult {
    address_components: MapAddressComponent[];
    formatted_address: string;
    geometry: MapGeometry;
    place_id: string;
    plus_code?: MapPlusCode;
    types: string[];
}

export interface MapAddressComponent {
    long_name: string;
    short_name: string;
    types: string[];
}

export interface MapGeometry {
    location: MapLocation;
    location_type: string;
    viewport: MapBounds;
    bounds?: MapBounds;
}

export interface MapBounds {
    northeast: MapLocation;
    southwest: MapLocation;
}

export interface MapLocation {
    lat: number;
    lng: number;
}

export class Property {
    constructor(public id: number,
        public title: string = "",
        public desc: string,
        public propertyType: string,
        public propertyStatus: string[],
        public city: string,
        public zipCode: string[],
        public neighborhood: string[],
        public street: string[],
        public location: Location,
        public formattedAddress: string,
        public features: string[],
        public featured: boolean,
        public priceDollar: Price,
        public priceEuro: Price,
        public bedrooms: number,
        public bathrooms: number,
        public garages: number,
        public area: Area,
        public yearBuilt: number,
        public ratingsCount: number,
        public ratingsValue: number,
        public additionalFeatures: AdditionalFeature[],
        public gallery: Gallery[],
        public plans: Plan[],
        public videos: Video[],
        public published: string,
        public lastUpdate: string,
        public views: number) { }
}
//update old property
export class InsertProperty {
    public title: string = "";
    public description: string = "";
    public currency: number = 0;
    public offer: Offer;
    public type: number = 0;
    public country: string = "";
    public city: number = 0;
    public location: string = "";
    public zipCode: string = "";
    public street: string = "";
    public area: number = 0;
    public owners: number = 0;
    public rooms: number = 0;
    public bedrooms: number = 0;
    public bathrooms: number = 0;
    public balconies: number = 0;
    public propertyAge: number = 0;
    public directionWest: boolean = false;
    public directionEast: boolean = false;
    public directionNorth: boolean = false;
    public directionSouth: boolean = false;
    public cladding: boolean = false;
    public empty: boolean = false;
    public heating: boolean = false;
    public gasLine: boolean = false;
    public internet: boolean = false;
    public elevator: boolean = false;
    public parking: boolean = false;
    public photos: Photo[] = [];
    public tags: number[] = [];
}
export class Offer {
    public sale: number;
    public rent: number;
    public invest: number;
    public swap: boolean;
    public currency: number;
}
export class Photo {
    constructor(
        public url: string,
        public description: string,
        public dateAdded: Date,
        public isMain: string,
        public publicId: string) { }
}
export class Currency {
    constructor(public id: number,
        public name: string,
        public sign: string,
        public localSign: string,
        public country: string) { }
}
export class Category {
    constructor(public id: number,
        public name: string,
        public description: string,
        public subCategory: SubCategory) { }
}
export class Tag {
    constructor(public id: number,
        public name: string,
        public description: string) { }
}
export class Country {
    constructor(public id: number,
        public code: string,
        public name: string,
        public nativeName: string) { }
}
export class City {
    constructor(public id: number,
        public code: string,
        public name: string,
        public nativeName: string,
        public latinName: string,
        public latitude: string,
        public longitude: string) { }
}
export class SubCategory {
    constructor(public id: number,
        public name: string,
        public description: string) { }
}

export class Area {
    constructor(public id: number,
        public value: number,
        public unit: string) { }
}

export class AdditionalFeature {
    constructor(public id: number,
        public name: string,
        public value: string) { }
}

export class Location {
    constructor(public id: number,
        public lat: number,
        public lng: number) { }
}

export class Price {
    public sale: number;
    public rent: number;
}


export class Gallery {
    constructor(public id: number,
        public small: string,
        public medium: string,
        public big: string) { }
}

export class Plan {
    constructor(public id: number,
        public name: string,
        public desc: string,
        public area: Area,
        public rooms: number,
        public baths: number,
        public image: string) { }
}

export class Video {
    constructor(public id: number,
        public name: string,
        public link: string) { }
}

export class Pagination {
    constructor(public page: number,
        public perPage: number,
        public prePage: number,
        public nextPage: number,
        public total: number,
        public totalPages: number) { }
}

