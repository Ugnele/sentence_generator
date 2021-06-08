# sentence_generator

An app that implements a 'sentence' generator. It works based on 4 services:
Service 1 is responsible for the front-end of an app;
Service 2 randomly selects a number from 1 to 5. That number is X (say) and it will represent the length of the sentence;
Service 3 randomly selects 20 words from CSV files (files for adjectives, adverbs, nouns and verbs), these words are then stored in an array of lists; 
Service 4 merges services 2 and 3 in such a way, that the sentence of length X is generated. It is constructed following the structure below:
switch length_X
    case 1: Noun
    case 2: Adjective + Noun
    case 3: Adverb + Adjective + Noun
    case 4: Verb +  Adverb + Adjective + Noun
    case 5: Verb +  Adverb + Adjective + Noun + AND + Noun


Relevant links:
Kanban board: https://dev.azure.com/ugnesarakauskaite0513/Sentence_Generator