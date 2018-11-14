public interface ICannonAI
{
    void SetTarget(double distance);
    double GetShootAngle();
    void FeedbackHitDistance(double distance);
}
