Feature: Attractie

@myTag
Scenario: BestaatAl
    Given attractie Draaimolen bestaat
    When attractie Draaimolen wordt toegevoegd
    Then moet er een error 403 komen

# Opdracht: voeg hier een scenario toe waarin een 404 wordt verwacht bij het deleten van een niet-bestaande attractie
@myTagw
Scenario: BestaatNietBijVerwijder
    Given attractie Python bestaat niet
    When attractie Python wordt verwijderd
    Then moet er een error 404 komen

@myTagw
Scenario: GastBestaatNietBijAanpassen
    Given attractie Python bestaat niet
    When attractie Python wordt opgevraagd
    Then moet er een error 404 komen
