## Problem: Ranking Poker Hands in Camel Cards

### Part One: Standard Hand Ranking

#### Context:
- Camel Cards is a poker-like game with unique rules.
- Hands consist of five cards with labels A, K, Q, J, T, 9, 8, 7, 6, 5, 4, 3, or 2.
- Hands are ranked based on type and individual card strength.

#### Hand Types (Strongest to Weakest):
1. **Five of a Kind:** All cards have the same label.
2. **Four of a Kind:** Four cards with the same label.
3. **Full House:** Three cards of one label and two cards of another.
4. **Three of a Kind:** Three cards with the same label.
5. **Two Pair:** Two sets of pairs with different labels.
6. **One Pair:** Two cards with the same label.
7. **High Card:** No pairs, ranked by highest card.

#### Tiebreaker Rules:
- Compare cards in descending order of importance.
- The hand with the higher card at any point wins.

#### Task:
- Rank each hand in a list of hands with their corresponding bids.
- Calculate total winnings by multiplying each hand's bid by its rank.

#### Example Input:
`32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483`
- Rank these hands and calculate total winnings.

### Part Two: Introducing Joker Rule

#### New Rule:
- **Joker (J) Cards:** Act as wildcards to form the strongest hand possible.
- Joker cards are the weakest in tiebreakers.

#### Modified Hand Ranking:
- Consider J cards as wildcards for determining hand type.
- For tiebreaking, treat J as its actual value, not the card it represents.

#### Example with Joker Rule:
`32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483`

- Re-rank these hands considering J as a wildcard.
- Calculate the new total winnings.

#### Objective:
- Apply the joker rule to the set of hands.
- Determine new ranks and total winnings.
