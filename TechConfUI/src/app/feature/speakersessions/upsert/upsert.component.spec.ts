import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpeakerSessionsUpsertComponent } from './upsert.component';

describe('SpeakerSessionsUpsertComponent', () => {
  let component: SpeakerSessionsUpsertComponent;
  let fixture: ComponentFixture<SpeakerSessionsUpsertComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SpeakerSessionsUpsertComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SpeakerSessionsUpsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
